    void Main()
    {
    	// Get translation
    	var translationObject = GetTranslationObject();
    	// Find friendly status based on combo
    	var friendly1 = translationObject.ComboStatusToFriendlyStatus[new StatusCombo(0, 30, 5)];
    	// Find combo based on friendly status
    	var combo1 = translationObject.FriendlyStatusToComboStatus[0];
    }
    public struct StatusCombo
    {
    	// Please note that fields are readonly for immutability.
    	// This is particularly important since the GetHashCode() value is used in dictionaries.
    
    	// Note that status fields can also be strings (because we use .GetHashCode() in GetHashCode()).
    	public readonly int Status1;
    	public readonly int Status2;
    	public readonly int Status3;
    	[JsonConstructor]
    	public StatusCombo(int status1, int status2, int status3)
    	{
    		Status1 = status1;
    		Status2 = status2;
    		Status3 = status3;
    	}
    
    	public override int GetHashCode()
    	{
    		unchecked
    		{
    			int hashCode = Status1.GetHashCode();
    			hashCode = (hashCode * 397) ^ Status2.GetHashCode();
    			hashCode = (hashCode * 397) ^ Status3.GetHashCode();
    			// ... Repeat for every extra statuscode you add
    			return hashCode;
    		}
    	}
    }
    
    public class TranslationObject
    {
    	public Dictionary<int, string> Status1Mapping;
    	public Dictionary<int, string> Status2Mapping;
    	public Dictionary<int, string> Status3Mapping;
    	public Dictionary<int, string> FriendlyStatus;
    
    	public Dictionary<int, StatusCombo> FriendlyStatusToComboStatus;
    	[JsonIgnore]
    	public Dictionary<StatusCombo, int> ComboStatusToFriendlyStatus;
    }
    
    private static TranslationObject _translationObject = null;
    public static TranslationObject GetTranslationObject()
    {
    	if (_translationObject == null)
    		lock ("Reading _translationObject")
    		{
    			_translationObject = JsonConvert.DeserializeObject<TranslationObject>(File.ReadAllText(@"TranslationTables.json"));
    			// Populate reverse lookup
    			_translationObject.ComboStatusToFriendlyStatus=new Dictionary<UserQuery.StatusCombo, int>();
    			foreach (var t in _translationObject.FriendlyStatusToComboStatus)
    				_translationObject.ComboStatusToFriendlyStatus.Add(t.Value, t.Key);
    
    		}
    	return _translationObject;
    }
