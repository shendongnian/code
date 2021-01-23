    public class PageConverter<TPage, TItem> : JsonConverter
            where TPage : IPage<TItem>, new()
            where TItem : new()
    {
        private readonly Regex _numberPostfixRegex = new Regex(@"\d+$");
        public override bool CanWrite
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(TPage));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = serializer.Deserialize<JObject>(reader);
            var page = new TPage();
            serializer.Populate(obj.CreateReader(), page); //Loads everything that isn't a part of the items. 
            page.PageItems = new List<TItem>();
            for (int i = 1; i <= page.Count; i++)
            {
                string index = i.ToString();
                //Find all properties that have a number at the end, then any of those that are the same number as the current index.
                //Put those in a new JObject.
                var jsonItem = new JObject();
                foreach (var prop in obj.Properties().Where(p => _numberPostfixRegex.Match(p.Name).Value == index))
                {
                    jsonItem[_numberPostfixRegex.Replace(prop.Name, "")] = prop.Value;
                }
                //Deserialize and add to the list.
                TItem item = jsonItem.ToObject<TItem>(serializer);
                page.PageItems.Add(item);
            }
            return page;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
