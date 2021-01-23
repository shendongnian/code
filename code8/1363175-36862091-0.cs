    public class ConditionCreator : IFluentAndOr
    {
        public IFluentAndOr And() { ... }
        public IFluentAndOr Or() { ... }
    }
    
    public interface IFluentAndOr
    {
        IFluentAndOr And();
        IFluentAndOr Or();
    }
