    public interface IProblem
    {
         List<Node> Points { get; set; }
         Object GetStartState();
         bool IsGoalState();
         Object GetSuccessor();
    }
