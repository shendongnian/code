    public class ScopeCounter<T> {
        private int count;
        public IDisposable BeginScope() {
            this.count++;
            return new Decounter { counter = this };
        }
        public bool IsOuterScope { get { return this.count == 1; } }
        private sealed class Decounter : IDisposable {
            internal ScopeCounter<T> counter;
            public void Dispose() {
                if (counter != null) {
                    counter.count--;
                    this.counter = null;
                }
            }
        }
    }
