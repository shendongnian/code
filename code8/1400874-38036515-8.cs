    public interface IState
    {    }
    public interface ITransition
    {    }
    // !!!!! - Here we add out specifier
    public interface ITransitionContainer<out TTransition, out TStateTo>
        where TTransition : ITransition
        where TStateTo : IState
    {
        Type StateTo
        {
            get;
        }
        TTransition Transition
        {
            get;
        }
    }
    public interface IStateContainer<T> where T : IState
    {
        T State
        {
            get;
        }
    }
    public class TransitionContainer<TTransition, TStateTo> : ITransitionContainer<TTransition, TStateTo>
        where TTransition : ITransition
        where TStateTo : IState
    {
        public TransitionContainer()
        {
            StateTo = typeof(TStateTo);
            Transition = Activator.CreateInstance<TTransition>();
        }
        public Type StateTo { get; private set; }
        public TTransition Transition { get; private set; }
    }
    
    public class StateContainer<T> : IStateContainer<T> where T : IState
    {
        private Dictionary<Type, ITransitionContainer<ITransition, IState>> _transitions =
            new Dictionary<Type, ITransitionContainer<ITransition, IState>>();
        public StateContainer()
        {
            State = Activator.CreateInstance<T>();
        }
        public T State { get; private set; }
        public int TransitionCount
        {
            get { return _transitions.Count; }
        }
        
        public void AddTransition<TTransition, TStateTo>()
            // !!!!!! - Here we add class constraints
            where TTransition : class, ITransition, new()
            where TStateTo : class, IState, new()
        {
            var transitionContainer = new TransitionContainer<TTransition, TStateTo>();
            
            _transitions.Add(typeof(TTransition), transitionContainer);
        }
    }
