    [CreateAssetMenu("MyHeightsAsset")]
    public class Heights : ScriptableObject
    {
    	public static Heights Load()
    	{
    		return Resources.Load("MyHeightsAsset");
    	}
    
    	public KeyValuePair[] valueMap;
    
    	[Serializable]
    	public class KeyValuePair
    	{
    		public MeasurableObjects obj;
    		public int value;
    	}
    
    	public enum MeasurableObjects
    	{
    		Avatar,
    		Dog
    	}
    }
