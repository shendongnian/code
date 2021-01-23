    public class Interface : MonoBehaviour
    {
    	private SharedData m_sharedData;
    
    	public void Initialize()
    	{
    		GameObject globalObj = GameObject.Find("Globals");
    		m_sharedData = globalObj.GetComponent<SharedData>();
            m_sharedData.LoadData(); // This is where I use something on the singleton.
    	}
    }
