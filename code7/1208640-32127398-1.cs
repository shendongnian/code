    public class someclass : IIndexable_String
	
	Type target = Type.GetType(DocumentType);
	// Instantiate
	IIndexable_String instance = (IIndexable_String)Activator.CreateInstance(target);
	foreach (Dictionary<string, string> PQList in LPQReq)
	{
		foreach (KeyValuePair<string, string> kvp in PQList)
		{
			// populate the member in the data class with the value from the MQ String
			target[kvp.Key] = kvp.Value;                                                
		} 
