    //Tool struct
    struct AStruct{
      int value;
    };
    
    //C# class used by EF:
    public class A{
        public int Value { get; set; }
        
        //Rest of ctors....
        public A(AStruct s)
        {
            Value = s.value;
        }
    
        public AStruct ToStruct(){
            return new AStruct
            {
                value = Value;
            }
        }
        //Rest of code here....
    }
