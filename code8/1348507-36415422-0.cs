    public class Card
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Name, Phone, Note);
        }
    }
