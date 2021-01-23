    public class TestClass
    {
        public IObject MyObject { get; set; }
        public bool MyBool { get; set; }
    
        public TestClass()
        {
            MyObject = MyBool ? (IObject) new Object2() : new Object1();
        }
    }
    
    public interface IObject { }
    public interface IOtherObject { }
    
    public class Object1 : IObject, IOtherObject
    {
    }
    
    public class Object2 : IObject
    {
    }
