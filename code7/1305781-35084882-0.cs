    public class SomeClass: IDisposable
    {
        public SomeClass(object somevalue) {
        }
        public int AnotherValue { get; set; }
        public int AdditionalValue { get; set; }
        internal void ImHere() {
            throw new NotImplementedException();
        }
        public void Dispose() {
            throw new NotImplementedException();
        }
    }
    static void Main(string[] args) {
        object somevalue = null;
        using (var something = new SomeClass(somevalue) { AnotherValue = 1, AdditionalValue = 2 }) {
            something.ImHere();
        }
    }
