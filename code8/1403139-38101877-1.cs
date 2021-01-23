    class CollectionOfDisposable : IDisposable {
        IList<IDisposable> Members {get;}
        public CollectionOfDisposable(IEnumerable<IDisposable> members) {
            Members = members.ToList();
        }
        public void Dispose() {
            foreach (IDisposable item in Members) {
                item.Dispose();
            }
        }
    }
