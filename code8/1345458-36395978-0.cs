    namespace XUnitRemote.Test
    {
        public class Tests
        {
            private readonly ITestOutputHelper _Output;
    
            public Tests(ITestOutputHelper output)
            {
                _Output = output;
            }
    
            [SampleProcessFact]
            public void OutOfProcess()
            {
                _Output.WriteLine("Process name: " + Process.GetCurrentProcess().ProcessName);
                Assert.Equal(5, 3);
            }
    
            [Fact]
            public void InProcess()
            {
                _Output.WriteLine("Process name: " + Process.GetCurrentProcess().ProcessName);
                Assert.Equal(5, 3);
            }
        }
    }
