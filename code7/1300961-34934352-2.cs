    public interface IRoot<TSecondary, TTeritary>
        where TSecondary : ISecondary
        where TTeritary : ITertiary
    {
        public TSecondary secondary
        public TTeritary tertiary
    }
