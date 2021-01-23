    public class MyClass 
    {
        ...
        // make a shallow copy
        public MyClass ShallowCopy()
        {
            return (MyClass) this.MemberwiseClone();
        }
    }
