    public abstract class ActionMethod
    {
        public abstract string Token { get; set; }
    }
    
    public class FirstMethod : ActionMethod
    {
        public string Value { get; set; }
    
        public override string Token
        {
            get;
            set;
        }
    }
