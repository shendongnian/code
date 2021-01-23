    class MenuItemJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (MenuItemCollection) || objectType==typeof(List<MenuItem>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var map=new Dictionary<int,JObject>();
            var collection = (List<MenuItem>) value;
            var root=new JObject();
            var nestedItems=collection.GroupBy(i => i.ParentId).ToLookup(g=>g.Key); //or we can simply check for item.Url==null but I believe this approach is more flexible
            
            foreach (var item in collection)
            {
                if (item.ParentId == null)
                {
                    var firstObj=new JObject();
                    root.Add(item.MenuName,firstObj);
                    map.Add(item.SiteMenuId,firstObj);
                    continue;
                }
                var parent = map[item.ParentId.Value];
                if (!nestedItems.Contains(item.SiteMenuId))
                {
                    parent.Add(item.MenuName,item.Url);
                    continue;
                }
                var jObj = new JObject();
                parent.Add(item.MenuName, jObj);
                map.Add(item.SiteMenuId, jObj);
            }
            writer.WriteRaw(root.ToString());
        }
    }
