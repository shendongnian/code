    sealed class RelatedInformation : IComparable<RelatedInformation>
    {
        public string First;
        public string Second;
        public string Third;
        public int CompareTo(RelatedInformation other)
        {
            return First.CompareTo(other.First);
        }
    }
    // ...
    var myList = new List<RelatedInformation>();
    // insert code that populates the list
    myList.Sort();
