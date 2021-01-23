    public class Hide : MonoBehaviour
    {
    	public float after = 5.0f;
    
    	void Start()
    	{ Invoke("Disable", after); }
    
    	void Disable()
    	{ gameObject.SetActive (false); }
    }
