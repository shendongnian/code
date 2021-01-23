    public class SomeType
    {
        public static SomeType FromDynamic(dynamic arg)
        {
             return new SomeType
             {
                  SomeProperty = arg.SomeProp
             }
        }
        
        public int SomeProperty {get; set; }
    }
