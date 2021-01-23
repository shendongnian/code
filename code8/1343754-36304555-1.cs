    public class rslideController : MonoBehaviour, ClientListener {
    
    	private Client client;
    
    	// Use this for initialization
    	void Start () {
    		this.client = GameObject.Find ("Manager").GetComponent<ClientManager>().Client;
    		this.client.AddListener (this);
    	}
    
    	void OnDestroy() {
    		this.client.RemoveListener (this);
    	}
        
        //...
    
    	public void OnFriendDisconnected(string username, int id){ }
    	public void OnFriendConnected(string username, int id){ }
    	public void OnReceiveMessage(string message){ }
    	public void OnAuthenticated(){ }
    	public void OnRejected(){ }
    	public void OnDisconnected(){ }
    }
