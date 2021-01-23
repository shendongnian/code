    public class CustomObject
    {
        public CustomObject(string text)
        {
            this.text = text;
        }
        public string text { get; set; }
        public Visibility visibility
        {
            get
            {
                if (text.StartsWith("http"))
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
        }
    }
