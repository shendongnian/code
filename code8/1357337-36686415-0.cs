    public abstract class Problem<T> where T:IGameState
    {
        protected Problem(T initialState)
        {
            InitialState = initialState;
        }
        public T InitialState { get; set; }
        /// <summary>
        /// Checks if the state is the goal state
        /// </summary>
        public abstract bool IsGoalState(T state);
        
    }
    public class EightPuzzleProblem<T> : Problem<T> where T : IGameState
    {
        private readonly T _goalState;
        public EightPuzzleProblem(T initialState, T goalState)
            : base(initialState)
        {
            _goalState = goalState;
        }
        public override bool IsGoalState(T state)
        {
            return _goalState.IsEqual(state);
        }
    }
    public interface IGameState
    {
        bool IsEqual(IGameState state);
    }
    public class EightPuzzleGameState : IGameState
    {
        private readonly int[,] _goalState =
        {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8},
        };
        public bool IsEqual(IGameState state)
        {
            //Compare state with _goalState
        }
    }
