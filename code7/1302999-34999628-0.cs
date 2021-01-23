    void Main()
    {
    	var config = Config.Qualities[MaterialQualities.Low];
    	var cost = config.Cost;
    	var value = config.Value;
    }
    
    public static class Config
    {
    	public static Dictionary<MaterialQualities, MaterialQuality> Qualities =
    		new Dictionary<MaterialQualities, MaterialQuality>
    		{
    			{ MaterialQualities.Low, new MaterialQuality { Value = 0.1F, Cost = 10 }},
    			{ MaterialQualities.Medium, new MaterialQuality { Value = 0.2F, Cost = 20 }}, 
    			{ MaterialQualities.High, new MaterialQuality { Value = 0.2F, Cost = 40 }},
    		};	
    }
    
    public class MaterialQuality
    {
    	public float Value { get; set; }
    	public int Cost { get; set; }
    }
    
    public enum MaterialQualities
    {
    	Low, Medium, High
    }
