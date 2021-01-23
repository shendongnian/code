    public class baseOutput
    {
        public string output;
    }
    
    public class baseInput
    {
        public string input;
    }
    
    public class ExtendOutput : baseOutput
    {
        public long id;
    }
    
    public class ExtendInput : baseInput
    {
        public long id;
    }
    
    public interface IBaseFoo<out T1, out T2>
    {
        public void DoSmth();
    }
    
    public class Bar : IBaseFoo<ExtendOutput, ExtendInput>
    {
        public void DoSmth()
        {
    
        }
    }
    
    public class Test
    {
        public void Show()
        {
    
        }
    
        private IBaseFoo<baseOutput, baseInput> CreateInstance()
        {
            return new Bar();
        }
    }
