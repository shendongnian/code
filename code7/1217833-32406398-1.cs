    internal class MyComparer : IEqualityComparer<DateTime> {
        private static readonly TimeSpan Span = TimeSpan.FromMinutes(5);
        public bool Equals(DateTime x, DateTime y){
            return (x - y).Duration() <= Span;
        }
        public int GetHashCode(DateTime obj) {
            return obj.Year.GetHashCode() ^ obj.Month.GetHashCode() ^ obj.Day.GetHashCode();
        }
    }
