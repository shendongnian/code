    public class Program
    {
        private static void Main(string[] args)
        {
            var json = @"{
               ""browser"":""Chrome"",
               ""call"":{
                  ""addEventListener"":199,
                  ""appendChild"":34,
                  ""createElement"":8,
                  ""getAttribute"":2170,
               },
               ""get"":{
                  ""linkColor"":1,
                  ""vlinkColor"":1
               },
               ""session"":""3211658131"",
               ""tmStmp"":""21316503513854""
            }";
            var clearCoatDataObject = ClearCoatDataObject.FromJson(json);
            foreach (var ccdi in clearCoatDataObject.Flatten())
            {
                Console.WriteLine(ccdi.ToJson());
            }
        }
        public class ClearCoatDataObject
        {
            public string browser { get; set; }
            public string session { get; set; }
            public string url { get; set; }
            public string tmStmp { get; set; }
            public string _id { get; set; }
            public PropertyDictionary create { get; set; }
            public PropertyDictionary call { get; set; }
            public PropertyDictionary get { get; set; }
            public PropertyDictionary set { get; set; }
            public static ClearCoatDataObject FromJson(string json)
            {
                return JsonConvert.DeserializeObject<ClearCoatDataObject>(json);
            }
            public String ToJson()
            {
                return JsonConvert.SerializeObject(this);
            }
            public ActionDictionary GetActions()
            {
                ActionDictionary actionTypes = new ActionDictionary();
                actionTypes.Add("create", create);
                actionTypes.Add("call", call);
                actionTypes.Add("get", get);
                actionTypes.Add("set", set);
                return actionTypes;
            }
            public ClearcoatDataItemCollection Flatten()
            {
                ClearcoatDataItemCollection retCollection = new ClearcoatDataItemCollection();
                // foreach constr in action
                ActionDictionary actionTypes = GetActions();
                foreach (var actionType in actionTypes)
                {
                    PropertyDictionary property = actionType.Value;
                    if (property != null)
                    {
                        foreach (KeyValuePair<string, int> propertyCount in property)
                        {
                            ClearCoatDataItem ccdi = new ClearCoatDataItem(this.session, this.url, actionType.Key, propertyCount.Key, propertyCount.Value);
                            retCollection.Add(ccdi);
                        }
                    }
                }
                return retCollection;
            }
        }
        // Dictionary Classes to hold:
        //      actions (
        //      
        public class PropertyDictionary : Dictionary<string, int> { }
        public class ActionDictionary : Dictionary<string, PropertyDictionary> { }
    }
