       public class ItemId
       {
            private string id;
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
       
       }
