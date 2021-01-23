    // The name of the class is vague. Not knowing
    // what your data represent, is quite difficult to 
    // give a proper name.
    public class Result
    {
        public int Number  { get; private set; }
        public string Text { get; private set; }
    
        public Result(int number, string text)
        {
            Number = number;
            Text = text;
        }
    }
