    public class Wrapper
    {
        private A a;
        private B b;        
    
        public Wrapper(A a)
        {
            this.a = a;
        }
    
        public Wrapper(B b)
        {
            this.b = b;
        }
    
        public int Prop { get { return (int)(a?.Prop ?? b?.Prop); } }
    }
    
    public static class Extension
    {
        public static int Sum(this Wrapper template, int input)
        {
            return template.Prop + input;
        }
    }
