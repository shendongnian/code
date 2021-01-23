    [Extension(Description = "Test Reporter Extension", EngineVersion="3.4")]
    public class MyTestEventListener : ITestEventListener
    {
        public void OnTestEvent(string report)
        {
            Console.WriteLine(report);
        }
    }
