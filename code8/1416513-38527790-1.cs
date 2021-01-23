      >     [
          {
            "id": 41,
            "customer": {
              "id": 2
            }
          }
        ]
    Unfortunately, there is no canonical way to convert this object hierarchy to a `DataTable`.  It is possible to nest data tables inside each other, however this canonically maps to a nested JSON *array* rather than a nested *object*.  In comments you wrote *I need to insert that data in SQL Server*.  So, how do you want this data to be modeled in the database?  
    One possibility would be to convert the nested objects to nested arrays of objects.  Having done this, automatic conversion will be possible.  However, it will now appear that each of your `order` objects can have multiple (e.g.) customers when this is in fact not true.  If this is satisfactory then the following method can be used:
        public static void ConvertObjectPropertiesToArrays(JContainer root)
        {
            var query = root.DescendantsAndSelf()
                .OfType<JProperty>()
                .Where(p => p.Parent is JObject && p.Value is JObject);
            foreach (var property in query.ToList())
            {
                var value = property.Value;
                var array = new JArray();
                property.Value = array;
                array.Add(value);
            }
        }
    It produces the following JSON:
  >     [
          {
            "id": 41,
            "customer": [
              {
                "id": 2
              }
            ]
          }
        ]
    Alternatively, you could flatten nested objects by bubbling their properties up to their parents.  The following method does this:
    
        public static void FlattenObjectPropertiesToParents(JContainer root)
        {
            var query = root.DescendantsAndSelf()
                .OfType<JProperty>()
                .Where(p => p.Parent is JObject && p.Value is JObject)
                .ToList();
            for (int i = query.Count - 1; i >= 0; i--)
            {
                var property = query[i];
                var value = (JObject)property.Value;
                var parent = (JObject)property.Parent;
                property.Remove();
                foreach (var item in value.Properties().ToList())
                {
                    item.Remove();
                    parent.Add(string.Format("{0}.{1}", property.Name, item.Name), item.Value);
                }
            }
        }
    It produces the following JSON which can be converted successfully to a `DataTable`:
     >     [
          {
            "id": 41,
            "customer.id": 2
          }
        ]
    Notice that the "id" property of the "customer" object has become "customer.id".
    As a third option, you could try deserializing nested objects as a `Dictionary<string, object>` -- though I have no idea whether the SQL Server adapter could handle such a data table.  To do this, you will need to manually replicate the logic of `DataTableConverter.ReadJson()` along the lines of the answer to [DateTime column type becomes String type after deserializing DataTable](https://stackoverflow.com/questions/37109154/datetime-column-type-becomes-string-type-after-deserializing-datatable/37126529#37126529) and modify [`GetColumnDataType(JsonReader reader)`](https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Converters/DataTableConverter.cs#L204) to return `typeof(Dictionary<string, object>)` for `JsonToken.StartObject`.
