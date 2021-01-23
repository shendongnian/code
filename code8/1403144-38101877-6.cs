    class CollectionOfDisposable<T> : IDisposable where T : IDisposable  {
        public IList<T> Members {get; private set;}
        public CollectionOfDisposable(IEnumerable<T> members) {
            Members = members.ToList();
        }
        public void Dispose() {
            var exceptions = new List<Exception>();
            foreach (var item in Members) {
                try {
                    item.Dispose();
                } catch (Exception e) {
                    exceptions.Add(e);
                }
            }
            if (exceptions.Count != 0) {
                throw new AggregateException(exceptions);
            }
        }
    }
