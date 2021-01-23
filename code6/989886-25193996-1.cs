    public class MatPair : IEquatable<MatPair>
    {
        public readonly string MatNeedsToExplainWhatThisRepresents;
        public readonly string MatNeedsToExplainThisToo;
        public MatPair(string matNeedsToExplainWhatThisRepresents,
            string matNeedsToExplainThisToo)
        {
            if (matNeedsToExplainWhatThisRepresents == null) throw new ArgumentNullException("matNeedsToExplainWhatThisRepresents");
            if (matNeedsToExplainThisToo == null) throw new ArgumentNullException("matNeedsToExplainThisToo");
            this.MatNeedsToExplainWhatThisRepresents = matNeedsToExplainWhatThisRepresents;
            this.MatNeedsToExplainThisToo = matNeedsToExplainThisToo;
        }
        [Obsolete]
        public override bool Equals(object obj)
        {
            return Equals(obj as MatPair);
        }
        public bool Equals(MatPair matPair)
        {
            return matPair != null
                   && matPair.MatNeedsToExplainWhatThisRepresents == MatNeedsToExplainWhatThisRepresents
                   && matPair.MatNeedsToExplainThisToo == MatNeedsToExplainThisToo;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return MatNeedsToExplainWhatThisRepresents.GetHashCode() * 31
                    ^ MatNeedsToExplainThisToo.GetHashCode();
            }
        }
        public override string ToString()
        {
            return "{" + MatNeedsToExplainWhatThisRepresents + ", "
                + MatNeedsToExplainThisToo + "}";
        }
    }
