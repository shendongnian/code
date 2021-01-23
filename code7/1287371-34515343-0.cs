    public class TestLambda
    {
        private string inputValue;
        private bool value
        {
            get { return inputValue == null; }
        }
        public TestLambda(string inputValue)
        {
            this.inputValue = inputValue;
        }
    }
