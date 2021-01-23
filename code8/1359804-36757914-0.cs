    void Main()
    {
        var awesome = Mock.Of<IAwesome>();
        var mock = Mock.Get(awesome);
        mock.Setup(awe => awe.RunSomething());
    
        var myClass = new myclass(awesome);
        myClass.MethodUnderTest();
    
        mock.Verify(awe => awe.RunSomething(), Times.Once);
    }
    
    public interface IAwesome
    {
        void RunSomething();
    }
    
    public class myclass
    {
        private IAwesome awesomeObject;
    
        public myclass(IAwesome awesomeObject)
        {
            this.awesomeObject = awesomeObject;
        }
    
    
        public void MethodUnderTest()
        {
            this.awesomeObject.RunSomething(); //I want to verify that RunSomething was called
        }
    }
