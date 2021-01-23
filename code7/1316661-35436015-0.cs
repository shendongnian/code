    void Main()
    {
    	var ItemResponses = new List<ItemResponse>();
    	
    	var result = ItemResponses
    		.Where(ir => ir.ItemID < 4 && ir.AssessmentInstance.ProjectID == 5)
    		.GroupBy(ir => ir.ItemID)
    		.Select(
    			grouped => new {
    				ItemID = grouped.Key,
    				Average = (double)grouped.Average(g => g.OptionValue),
    				ProportionHighScore = grouped.ProportionHighScore(1, 2, 3, 4, 5)
    			}
    		);
    		
    	result.Dump();
    }
    
    public class ItemResponse 
    {
    	public int ItemID { get; set; }
    	public int OptionValue { get; set; }
    	public AssessmentInstanceItem AssessmentInstance { get; set; }
    }
    
    public class AssessmentInstanceItem
    {
    	public int ProjectID  { get; set; }
    }
    
    public static class ItemResponseExtensions
    {
    	public static double ProportionHighScore(this IGrouping<int, ItemResponse> values, params int[] ResponseOptionID)
    	{
    		double count = 0;
    		double total = values.Count();
    		
    		foreach (int r in ResponseOptionID)
    			count += (double)values.Where(g => g.OptionValue == r).Count();
    		
            return count / total;
    	}
    }
