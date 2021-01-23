    namespace ManagerLibrary
    {
        public delegate int Operation(int x, int y);
        public class CalculationManager
        {
            public event Operation OperationNeeded;
            public int? Operate(int x, int y)
            {
                return (Operate != null)
                    ? Operate(x, y)
                    : (int?)null;
            }
        }
    }
    //In some other library
    using ManagerLibrary;
    namespace OperationLibrary
    {
        public class MathOperation
        {
            public CalculationManager Manager { get; set; }
            public MathOperation(CalculationManager manager)
            {
                Manager = manager;
                Manager.OperationNeeded += Manager_OperationNeeded;
            }
            int Manager_OperationNeeded(int x, int y)
            {
                return x + y;
            }
        }
    }
    //Usage (maybe in a third library)
    var manager = new CalculationManager();
    var operation = new MathOperation(manager);
    var result = manager.Operate(2, 3);
