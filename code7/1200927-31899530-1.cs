    public class MoverBolt : MonoBehaviour {
    	public void Start () 
    	{
    		Debug.Log("MoverBolt.Start() was called");
    	}
    }
    public class PlayerControl : MonoBehaviour {
    	[SerializeField]
    	private MoverBolt _moverBolt;
    
    	void Start () 
    	{
    		_moverBolt.Start();
    	}
    }
