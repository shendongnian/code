    public abstract class Wrapper {
        public int WrapperId { get; set; }
        public string Name { get; set; }
    }
    public class ParentWrapper: Wrapper{}
    public class ChildWrapper:ParentWrapper{}
    public class GrandChildWrapper : ChildWrapper { }
    public abstract class Table
    {
        public int TableId { get; set; }
        public string ExpiryDate { get; set; }
        public Wrapper Wrapper { get; set; }
        public Wrapper ChildWrapper { get; set; }
    }
    public class ParentTable:Table{}
    public class ChildTable:Table{}
    public class GrandChildTable:Table{}
