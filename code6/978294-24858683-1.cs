       public class ItemId
       {
            private string _id;
            public string ID
            {
                get { return _value; }
                set
                {
                    //do some formatting here
                    _id= value;
                }
            }
            public ItemId(string id)
            {
                ID = id
            }
            public override string ToString()
            {
                //do some extra formatting here if needed
                return Value;
            }
       }
