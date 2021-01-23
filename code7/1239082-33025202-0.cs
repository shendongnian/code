    public class Computer : IRepairable
    {
        public double GetRepairCost()
        {
            return (this.HoursWorked * 50) + PartsCost;
        }
    }
