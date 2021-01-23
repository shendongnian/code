    public class Row
    {
        public  List<string> Elements { get; private set; }
        public Row()
        {
            Elements = new List<string>();
        }
        public Row(List<string> elements)
        {
            Elements = elements;
        }
    }
