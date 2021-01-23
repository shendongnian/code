    using System;
    public abstract class Employee
    {
        public string name;
        public decimal basepay;
        public Employee(string name, decimal basepay)
        {
            this.name = name;
            this.basepay = basepay;
        }
        public abstract decimal CalculatePay();
    }
    public class SalesEmployee : Employee
    {
        public decimal salesbonus; // Additional field
        public SalesEmployee(string name, decimal basepay, decimal salesbonus) : base(name, basepay)
        {
            this.salesbonus = salesbonus; // Create new field
        }
        public override decimal CalculatePay() // Override abstract
        {
            return basepay + salesbonus;
        }
        public decimal CalculateExtraBonus() // Not an override 
        {
            return basepay + ((decimal)0.5 * salesbonus); // Belongs to this class only
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SalesEmployee employee1 = new SalesEmployee("Alice", 1000, 500);
            decimal aliceBonus = employee1.CalculateExtraBonus();
            Console.WriteLine(aliceBonus);
        }
    }
