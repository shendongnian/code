    public interface ITransition
    {
    }
    public class SomeTransition : ITransition
    {
    }
    public interface ITest<TTransition>
        where TTransition : ITransition
    {
        TTransition Value { get; }
    }
    public class SomeTest<TTransition> : ITest<TTransition>
        where TTransition : ITransition
    {
        public TTransition Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
