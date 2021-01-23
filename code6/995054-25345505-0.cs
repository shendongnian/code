    public class Test : MonoBehaviour 
    {
    	void Start()
    	{
    		foo("abc", "def", "ghi");
    	}
    
    	private void foo(string bar, params string[] baz) 
    	{
    		Debug.Log(baz.Length);
    	}
    }
 
