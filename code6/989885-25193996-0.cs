    public class KylePair : IEquatable<KylePair>
    {
        public readonly string KyleNeedsToExplainWhatThisRepresents;
        public readonly string KyleNeedsToExplainThisToo;
        public KylePair(string kyleNeedsToExplainWhatThisRepresents,
            string kyleNeedsToExplainThisToo)
        {
            if (kyleNeedsToExplainWhatThisRepresents == null) throw new ArgumentNullException("kyleNeedsToExplainWhatThisRepresents");
            if (kyleNeedsToExplainThisToo == null) throw new ArgumentNullException("kyleNeedsToExplainThisToo");
            this.KyleNeedsToExplainWhatThisRepresents = kyleNeedsToExplainWhatThisRepresents;
            this.KyleNeedsToExplainThisToo = kyleNeedsToExplainThisToo;
        }
        [Obsolete]
        public override bool Equals(object obj)
        {
            return Equals(obj as KylePair);
        }
        public bool Equals(KylePair kylePair)
        {
            return kylePair != null
                   && kylePair.KyleNeedsToExplainWhatThisRepresents == KyleNeedsToExplainWhatThisRepresents
                   && kylePair.KyleNeedsToExplainThisToo == KyleNeedsToExplainThisToo;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return KyleNeedsToExplainWhatThisRepresents.GetHashCode() * 31
                    ^ KyleNeedsToExplainThisToo.GetHashCode();
            }
        }
        public override string ToString()
        {
            return "{" + KyleNeedsToExplainWhatThisRepresents + ", "
                + KyleNeedsToExplainThisToo + "}";
        }
    }
