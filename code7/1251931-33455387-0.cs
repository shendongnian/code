    class ThreeTupleConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new List<Type> { typeof(Tuple<int, int, int>) }; }
        }
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            int item1 = (int)dictionary["Item1"];
            int item2 = (int)dictionary["Item2"];
            int item3 = (int)dictionary["Item3"];
            return new Tuple<int, int, int>(item1, item2, item3);
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
