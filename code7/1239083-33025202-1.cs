    public class Laptop : Computer
    {
        public new double GetRepairCost()
        {
            return base.GetRepairCost() + 10;
        }
    }
