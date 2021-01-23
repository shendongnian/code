    public interface IRoll {
        IEnumerable<ICut> Cuts { get; }
        ... // add other useful methods here
    }
    public abstract class AbstractRoll<T> : IRoll where T : ICut, new {
        ...
        public IEnumerable<ICut> Cuts {
            get {
                return curs.Cast<ICut>();
            }
        }
        ... // implement other useful methods here
    }
