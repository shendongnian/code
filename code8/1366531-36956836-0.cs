    public class Title
    {
        public string Title { get; set; }
        /* If you really need the conversion for something else...
        public static implicit operator Title(string title)
        {
            return new Title { Title = title };
        }
        */
    }
