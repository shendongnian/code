    public interface A 
    {
    }
    public class B : MonoBehaviour, A 
    {
    	void Start () 
    	{
    		Debug.Log(this is A); // Will print True.
    	}
    }
