    public class BusinessLayerClass
        {
            [LogMethod] 
            public string BusinessLayerMethod()
            {
                DataLayerClass dataLayerClass = new DataLayerClass();
               return  dataLayerClass.DataLayerMethod();
            }
        }
