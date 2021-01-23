    public class MyClass
    {
        public IEnumerable<MyClass> AsIEnumerable
        {
            get
            {
                yield return this;
            }
        }
    }
            
