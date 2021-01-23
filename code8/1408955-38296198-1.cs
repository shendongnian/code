    public class Order
    {
        public bool HasOilChange { get; set; }
        public bool HasLubeJob { get; set; }
        public bool HasRadiatorRush { get; set; }
        public bool HasTransmissionFlush { get; set; }
        public bool HasInspection { get; set; }
        public bool HasTireRotation { get; set; }
        public bool HasMufflerReplacement { get; set; }
        public decimal PartsCost { get; set; }
        public decimal LaborsCost { get; set; }
    }</code></pre>
<h2>Calculation of the Order </h2>
    public class OrderCalculator
    {
        List<IExpenseRule> rules = new List<IExpenseRule>();
    
        //all your rules get added here
        public OrderCalculator()
        {
            rules.Add(new OilChangeRule());
            rules.Add(new LubeJobRule());
            rules.Add(new TireRotationRule());
            rules.Add(new TaxOnPartsRule());
        }
    //Runs all your calculations and returns the total based on the rules you feed and your order state
    public decimal CalculateTotal(Order customerOrder)
    {
        var total = 0m;
        total = rules.Sum(rule => rule.CalculateExpense(customerOrder));
        return total;
    }
}
<h2>Example Rules</h2>
    public class OilChangeRule : IExpenseRule
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
    }
<h2>What your Form code looks like after the refactor </h2>
    public Order BuildOrder()
    {
        var currentOrder = new Order();
        currentOrder.HasOilChange = oilChangeCheckBox.CheckState;
        currentOrder.HasLubeJob = lubeJobCheckBox.CheckState;
        currentOrder.HasRadiatorRush = radiatorRushCheckBox.CheckState;
        currentOrder.HasTransmissionFlush = transmissionFlushCheckBox.CheckState;
        currentOrder.HasInspection = inspectionCheckBox.CheckState;
        currentOrder.HasMufflerReplacement = replaceMufflerCheckBox.CheckState;
        currentOrder.HasTireRotation = tireRotationCheckBox.CheckState;
        currentOrder.PartsCost = Decimal.Parse(partsTextBox.Text);
        currentOrder.LaborsCost = Decimal.Parse(laborTextBox.Text);
        return order;
    }
    
    private void calculateButton_Click(object sender, EventArgs e)
    {
       var totalCalculator = new OrderCalculator();
       var partsCalculator = new PartsCalculator();
       var serviceCalculator = new ServiceCalculator();
       var order = BuildOrder();
       var totalCost = totalCalculator.CalculateTotal(order);
       var partsCost = partsCalculator.CalculateTotal(order);
       var serviceCost = serviceCalculator.CalculateTotal(order);
       //Do what you need to with the totals here;
       totalFeesAnsLabelBox.Text = totalCost.ToString();
    }
