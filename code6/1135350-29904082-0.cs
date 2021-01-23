    public class Result
    {
        public int Number { get; private set; }
        public int Text { get; private set; }
    
        public Result(int number, string text)
        {
            Number = number;
            Text = text;
        }
    }
