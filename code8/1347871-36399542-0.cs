    public class Envelope<T> {
        public T Result { get; private set; }
    }
    public class Envelopes<T> {
       public Paging Paging { get; private set; }
       public List<T> Results { get; private set; }
    }
