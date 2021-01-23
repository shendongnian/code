    public class BaseClass
    {
    }
    public class BaseClass<T, U, V> : BaseClass
    {
        public T Extension1 { get; set; }
        public U Extension2 { get; set; }
        public V Extension3 { get; set; }
    }
    public class ClassThatIsUsingSpecificBaseClass
    {
        public void Test(BaseClass<int, int, string> baseClass)
        {
            //baseClass.Extension1 ...;
            //baseClass.Extension2 ...;
        }
    }
    public class ClassThatIsUsingBaseClass
    {
        public void Test(BaseClass baseClass)
        {
        }
    }
