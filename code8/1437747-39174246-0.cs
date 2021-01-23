     string json = "test.com/json..."; // actual API call url
     DataTable dt = toDataTable(json);
     GridView1.DataSource = dt;
     GridView1.DataBind();
 
    public static DataTable toDataTable(string json)
            {
                var result = new DataTable();
    
                var obj = JObject.Parse(json);
                var jArray = new JArray(obj.Values());
                //Initialize the columns
                foreach (var row in jArray)
                {
                    foreach (var jToken in row)
                    {
                        var jproperty = jToken as JProperty;
    
                        if (jproperty == null) continue;
                        if (result.Columns[jproperty.Name] == null)
                            result.Columns.Add(jproperty.Name,typeof(string));
                    }
                }
                foreach (var row in jArray)
                {
                    var datarow = result.NewRow();
                    foreach (var jToken in row)
                    {
                        var jProperty = jToken as JProperty;
                        if (jProperty == null) continue;
                        datarow[jProperty.Name] = jProperty.Value.ToString();
                    }
                    result.Rows.Add(datarow);
                }
    
                return result;
            }
