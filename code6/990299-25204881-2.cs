    public class TestRunner
    {
        public void RunTests(params Action[] tests)
        {
            foreach (var test in tests)
            {
                test.Invoke();
            }
        }
    }
