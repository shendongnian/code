    public class Dependencies
        {
            private static ISolve _solver;
            public static ISolve Solver
            {
                get
                {
                    if (_solver == null)
                        throw new SolverNotConfiguratedException();
                    return _solver;
                }
                set
                {
                    _solver = value;
                }
            }
        }
