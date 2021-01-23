    public class YourClass
    {
        private Solver _solver;
        private Solver MySolver
        {
            get {
                if (_solver == null) _solver = ctx.MkSolver();
                return _solver;
            }
        }
        // ...
