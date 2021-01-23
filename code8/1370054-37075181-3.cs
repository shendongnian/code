    public class MyJSON
    {
        public MyJSON(JObject json)
        {
            FirstOption = json;
            FirstOptionValid = true;
        }
        public MyJSON(File json)
        {
            SecondOption = json;
            SecondOptionValid = true;
        }
        public JObject FirstOption { get; private set; }
        public bool FirstOptionValid { get; private set; }
        public File SecondOption { get; private set; }
        public bool SecondOptionValid { get; private set; }
        public static implicit operator MyJSON(File json)
        {
            return new MyJSON(json);
        }
        public static implicit operator MyJSON(JObject json)
        {
            return new MyJSON(json);
        }
    }
