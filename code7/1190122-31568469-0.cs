    [DebuggerTypeProxy(typeof (StateDebugView))]
    internal class State
    {
        internal List<int> MQueue { get; private set; }
    
    }
    
    internal sealed class StateDebugView
    {
        private readonly State _sealedState;
    
        public StateDebugView(State sealedState)
        {
            _sealedState = sealedState;
        }
    
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public int[] Items
        {
            get { return _sealedState.MQueue.ToArray(); }
        }
    }
