    ...
    using UnityEngine.Events;
    
    // example, function has one float argument:
    // ADD THIS at the top of the file:
    [System.Serializable]
    public class _UnityEventFloat:UnityEvent<float> {}
    
    public class SomeThingHappens : MonoBehaviour
    {
    	public _UnityEventFloat changedLength;
    	public _UnityEventFloat changedHeight;
    	
        ... and then ... 
    	
    	void ProcessValues(float v)
    	{
    		....
    		if (changedLength != null) changedLength.Invoke(1.4455f);
    	}
    }
