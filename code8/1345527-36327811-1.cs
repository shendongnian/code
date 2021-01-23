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
            if(entry.Value is int)
            {
                int num = entry.Value;
            }
            else if(entry.Value is string)
            {
                string someString = entry.Value;
            }
            else if(entry.Value is MyCustomClass)
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
