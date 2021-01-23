    public interface ITyped
    {
        int Type { get; }
    }
    public class Connection : ITyped
    {
        public string Name { get; set; } // NOTE: public setters are Bad Code(tm) for anything but the dumbest DTO objects
        public int Type { get { return 1; } } // specify type for connections here
    }
    
