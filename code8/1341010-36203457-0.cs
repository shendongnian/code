        public interface IMyType 
                {
                    string Result(); //or whatever return type you're expecting.
                }
   
    2. and three classes which implement it:
        
             public class Type1 : IMyType
                {
                    public string Result()
                    {
                        // do something
                    }
                }
       (repeat for Type2 and Type3)
         
   
    
