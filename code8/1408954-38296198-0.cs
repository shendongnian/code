    public interface IExpenseRule
    {
    	decimal CalculateExpense(Order customerOrder);
    }
    
    public class Order
    {
    	public bool HasOilChange { get; set; }
    	public bool HasLubeJob { get; set; }
    	public bool HasRadiatorRush { get; set; }
    	public bool HasTransmissionFlush { get; set; }
    	public bool HasInspection { get; set; }
    	public bool HasTireRotation { get; set; }
    	public bool HasMufflerReplacement { get; set; }
    }
    
    
    public class OrderCalculator
    {
    	List<IExpenseRule> rules = new List<IExpenseRule>();
    
    	public OrderCalculator()
    	{
    		rules.Add(new OilChangeRule());
    		rules.Add(new LubeJobRule());
    		rules.Add(new TireRotationRule());
    	}
    
    	public decimal CalculateTotal(Order customerOrder)
    	{
    		var total = 0m;
    		total = rules.Sum(rule => rule.CalculateExpense(customerOrder));
    		return total;
    	}
    }
    
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
