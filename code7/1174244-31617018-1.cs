    public static class FakeSomeDataResult
    {
    	public static usp_get_Some_Data_Result Create(int index)
    	{
    		return new usp_get_Some_Data_Result
    		{
    			SomeFriendlyNameProperty = string.Format("Some Data Result {0}", index),
    		};
    	} 
    }
