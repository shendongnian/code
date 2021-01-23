    void Main()
    {
        IAwesome awesome    = Mock.Of<IAwesome>();
        Mock<IAwesome> mock = Mock.Get(awesome);
        mock.Setup(m => m.RunSomething());
        
        MyClass myClass = new MyClass(awesome);
        myClass.MethodUnderTest();
    
        mock.Verify(m => m.RunSomething(), Times.Once);
    }
    
    public interface IAwesome
    {
        void RunSomething();
    }
    
    public class MyClass
    {
        private IAwesome awesomeObject;
    
        public myclass(IAwesome awesomeObject)
        {
            this.awesomeObject = awesomeObject;
        }
       
        public void MethodUnderTest()
        {
            this.awesomeObject.RunSomething();
        }
    }
