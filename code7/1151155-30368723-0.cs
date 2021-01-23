        public class MyThing : ThirdPartyXyz.SomeFancyBaseClass
        {
            public virtual new IReadOnlyDictionary<string, string> myMap;
            {
                get { return base.myMap; }
            }
     
            public string GetHeadline()
            {
                // this will use your 'virtual new myMap'!
                return "[" + this.myMap["title"] + "]";
            }
        }
