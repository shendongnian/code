    public class Company : IEnumerable
    {
        public IEnumerator Enumerator { get; set; }
        public IEnumerator GetEnumerator()
        {
            return Enumerator;
        }
        // other members
    }
