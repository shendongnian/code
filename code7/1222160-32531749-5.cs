    public class ProductionWorker : Employee
    {
        public override string ToString()
        {
            return String.Format("{0} ({1}), production", Name, EmployeeID);
        }
    }
