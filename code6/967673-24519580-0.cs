    internal interface IPowerToolStrategy
    {
        void Execute(PowerTool powerTool);
    }
    public class RedSquareJackhammer : IShape
    {
        private readonly IPowerToolStrategy _strategy;
        internal RedSquareJackhammer(IPowerToolStrategy strategy)
        {
            _strategy = strategy;
        }
        public void DoShape(PowerTool powerTool)
        {
            _strategy.Execute(powerTool);
        }
    }
