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
<h2>Calculation of the Order </h2><p>Here is where we apply the rules to our calculations. The constructor is where all the rules are added to the rule collection. The CalculateTotal iterates over the rules. A rule is only concerned with whatever item it has to calculate. Each rule's result gets added together to get the total. The Sum method is a Linq extension used to add the results of the rules together. You could use a for loop if you want instead.</p>
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
