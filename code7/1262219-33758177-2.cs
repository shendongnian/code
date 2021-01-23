    public class MyViewModel
    {
        public MyViewModel
        {
            TheStrings = new string[4];
            TheDates = new DateTimeOffset[2];
        }
    
        public string TheStrings { get; private set; }
        public DateTimeOffset TheDates { get; private set; }
    }
