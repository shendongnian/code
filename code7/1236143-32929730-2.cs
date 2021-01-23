    public class TestClass : ITestInterface
    {
        public delegate void SampleDelegate();
        public event SampleDelegate SampleEvent;
        private void FireEvent()
        {
            var handler = SampleEvent;
            if (handler != null)
                handler();
        }
    }
    public interface ITestInterface
    {
        event TestClass.SampleDelegate SampleEvent;
    }
