    public class TestLambda
    {
        private string inputValue; // necessary
        private bool value => inputValue == null;
    
        public TestLambda(string inputValue)
        {
            this.inputValue = inputValue;
    
        }
    }
