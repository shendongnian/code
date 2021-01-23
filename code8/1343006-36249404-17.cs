    ...
    using UnityEngine.Events;
    
    // magic line of code...
    [System.Serializable] public class _UnityEventFloat:UnityEvent<float> {}
    
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
