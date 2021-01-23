    <pre><code>public class OilChangeRule : IExpenseRule
    {
        public const decimal OilChangeCost = 26.00m;
    
        public decimal CalculateExpense(Order customerOrder)
        {
            return customerOrder.HasOilChange ? OilChangeCost : 0;
        }
    }
    
    public class LubeJobRule : IExpenseRule
    {
        public const decimal LubeJobCost = 18.00m;
    
        public decimal CalculateExpense(Order customerOrder)
        {
            return customerOrder.HasLubeJob ? LubeJobCost : 0;
        }
    }
    
    
    public class TireRotationRule : IExpenseRule
    {
        public const decimal TireRotationCost = 20.00m;
    
        public decimal CalculateExpense(Order customerOrder)
        {
            return customerOrder.HasTireRotation ? TireRotationCost : 0;
        }
    }
    
    public class TaxOnPartsRule : IExpenseRule 
    {
        public const decimal TaxPercentageOnParts = 0.6m;
    
        public decimal CalculateExpense(Order customerOrder)
        {
            var taxOnParts = customerOrder.PartsCost * TaxPercentageOnParts;
            return taxOnParts;
        }
    }</code></pre>
