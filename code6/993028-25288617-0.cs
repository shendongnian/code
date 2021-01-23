    public class AxiomSubset : IComparer<AxiomSubset>
    {
        public int Compare(AxiomSubset x, AxiomSubset y)
        {
            if (x.CC.CompareTo(y.CC) != 0)
            {
                return x.CC.CompareTo(y.CC);
            }
            else if (x.term.CompareTo(y.term) != 0)
            {
                return x.term.CompareTo(y.term);
            }
            else
            {
                return 0;
            }
        }
    }
