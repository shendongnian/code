    static Term NewTerm(Term t)
    {
        noOfTerms++;   //  defined as class variable somewhere else
        return t;
    }
    static void Main(string[] args)
    {
        var context = SolverContext.GetContext();
        var model = context.CreateModel();
        double sqrt2 = Math.Sqrt(2.0);
        var t = new Decision(Domain.RealRange(-sqrt2, +sqrt2), "t");
        var u = new Decision(Domain.RealRange(-2 * sqrt2, +2 * sqrt2), "u");
        model.AddDecisions(t, u);
        Term P = NewTerm(2 * t * t / (3 * t * t + u * u + 2 * t) - (u * u + t * t) / 18);
        model.AddGoal("objective", GoalKind.Maximize, P);
        Console.WriteLine("Constraints: " + model.Constraints.Count());
        Console.WriteLine("Decisions:   " + model.Decisions.Count());
        Console.WriteLine("Goals:       " + model.Goals.Count());
        Console.WriteLine("Terms:       " + noOfTerms);
        Solution sol = context.Solve();
        Report report = sol.GetReport();
        Console.WriteLine(report);
        Console.WriteLine();
    }
