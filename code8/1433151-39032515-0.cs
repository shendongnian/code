    public interface IStrategy
    {
        bool IsApplicable(YourClass instance);
        void Apply(YourClass instance);
    }
