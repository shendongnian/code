    // Base class for all InputVOs
    public abstract InputVOBase
    {
        public bool isEnabled;
    }
    // InputVO for a specific data-type
    public class InputVO<T> : InputVOBase
    {
        public T Value;
    }
