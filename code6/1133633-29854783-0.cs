    public class Test
    {
        public string Title { get; set; }
        public int Size 
        { 
            get
            {
               return (string.IsNullOrEmpty(Title)) ? 0 : Title.Length;
            } 
        }
    }
