     public class CompositeType
        {
          private  bool boolValue;
          private  string stringValue = "";
    
            [DataMember]
            public bool BoolValue
            {
                get { return boolValue; }
                set { boolValue = value; }
            }
    
            [DataMember]
            public string StringValue
            {
                get { return stringValue; }
                set { stringValue = value; }
            }
        }
