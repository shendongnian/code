    public class IndexLetterPair IEquatable<IndexLetterPair>
    {
        public int Index { get; set; }
        public char Letter { get; set; }
        public override int GetHashCode()
        {
            return new { Index = this.Index, Letter = this.Letter }.GetHashCode();
        }
        // (new IndexLetterPair() as object).Equals(new IndexLetterPair());
        public override bool Equals(object obj)
        {
            return (this.GetHashCode() == obj.GetHashCode());        
        }
        // new IndexLetterPair().Equals(new IndexLetterPair());
        public bool Equals(IndexLetterPair other)
        {
            return (this.GetHashCode() == other.GetHashCode());
        }
    }
