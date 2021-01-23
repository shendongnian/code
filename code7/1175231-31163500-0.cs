    public interface IValidation
    {
    	void AddError(string key, string errorMessage);
    	bool IsValid { get; }
    }
    
    public class MVCValidation : IValidation
    {
    	private ModelStateDictionary _modelStateDictionary;
    
    	public MVCValidation(ModelStateDictionary modelStateDictionary)
    	{
    		_modelStateDictionary = modelStateDictionary;
    	}
    	public void AddError(string key, string errorMessage)
    	{
    		_modelStateDictionary.AddModelError(key, errorMessage);
    	}
    	public bool IsValid
    	{
    		get
    		{
    			return _modelStateDictionary.IsValid;
    		}
    	}
    }
