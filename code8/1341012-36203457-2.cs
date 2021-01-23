        public interface IMyType 
                {
                    string Result(); 
                    string Input {get; set;}
                }
   
    2. and three classes which implement it:
        
             public class Type1 : IMyType
                {
                    public string Result()
                    {
                        // do something
                    }
                    public string Input {get; set;}
                }
       (repeat for Type2 and Type3)
         
   
    
