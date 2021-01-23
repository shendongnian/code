    public class Tests
    {
        public void TestOne() {
        }
    
        public void TestTwo() {
        }
    }
    ...
    var runner = new TestRunner();
    var tests = new Tests();
    runner.RunTests(tests.TestOne, tests.TestTwo);
