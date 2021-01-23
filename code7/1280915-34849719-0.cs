    public class BaseClass {
        public string Id {get;set;}
    
        public readonly string type;
        public BaseClass()
        {
            type = this.GetType().Name;
        }
    }
