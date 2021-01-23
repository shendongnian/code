    public class DynamicParse
    {      
    
        // other properties
    
        public dynamic Value {get;set;}
    }
    
    // wcf method
    public void PostData(List<DynamicParse> list)
    {
        // parse list[0].Value
        foreach(var entry in list)
        {
            Type valType = entry.Value.GetType();
            if(valType is int)
            {
                int num = entry.Value;
            }
            else if(valType is string)
            {
                string someString = entry.Value;
            }
            else if(valType is MyCustomClass)
            {
                MyCustomClass myClass = entry.Value;
                // Do something
            }
            else
            {
                // Do something
            }
        }    
    }
