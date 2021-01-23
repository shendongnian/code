    public class QuarterComparer : IComparer<Quarter>
    {
        int IComparer<Quarter>.Compare(Quarter p, Quarter q)
        {
            return p.Year < q.Year
                ? -1
                : p.Year == q.Year
                    ? p.Quarter < q.Quarter
                        ? -1
                        : p.Quarter == q.Quarter
                            ? 0
                            : 1
                    : 1;
        }
        public int Compare(Quarter p, Quarter q)
        {
            return (this as IComparer<Quarter>).Compare(p, q);
        }
    }
