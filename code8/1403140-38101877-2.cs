    class CollectionOfDisposable<T> : IDisposable where T : IDisposable  {
        IList<T> Members {get;}
        public CollectionOfDisposable(IEnumerable<T> members) {
            Members = members.ToList();
        }
        public void Dispose() {
            // An implementation has to be more careful than that:
            // use try-catch, make an aggregate exception in case some of the calls throw, etc.
            foreach (var item in Members) {
                item.Dispose();
            }
        }
    }
