    public class Example {
        public long Id { get; set; } // sortable
        public Nullable<long> Id2 { get; set; } // not sortable
        public SomeOwnClass Ref { get; set; } // not sortable
    }
