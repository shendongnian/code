    // It must be a parameterless method which returns no value
    public delegate void Action();
    
    // vs
    
    // It must be a class which implements a parameterless method "Do"
    // which returns no value
    public interface Action
    {
        void Do();
    }
