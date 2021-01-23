    interface ITest
    {
        object GetValue();
    }
    
    public class Test : ITest
    {
        public object GetValue() { return null; }
    
        // just a public method on our class
        public float GetValue() { return 0.0f; }
    }
