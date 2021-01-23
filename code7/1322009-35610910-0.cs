    public class Overhour
    {
        ...
        public int? AccountingId { get; set; } // optional
        public virtual Accounting Accounting { get; set; }
    }
    public class Accounting
    {
        ...
        public int OverhourId { get; set; } // required
        public virtual Overhour Overhour { get; set; }
    }
