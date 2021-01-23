    public class RotationStorage : public MonoBehaviour
    {
    	private Quaternion m_imageRotation = Quaternion.identity;
    
    	void Awake()
    	{
    		DontDestroyOnLoad(gameObject);
    	}
    
    	void SetRotation(Quaternion rotation)
    	{
    		m_imageRotation = rotation;
    	}
    
    	void OnLevelWasLoaded(int level)
    	{
    		if (Application.loadedLevelName == "Your starting scene")
    		{
    			GameObject image = GameObject.Find("name of your object");
                //If the rotation hasn't been set yet don't set the image' rotation.
    			if(image != null && m_rotation != Quaternion.identity)
    			{
    				image.transform.rotation = m_imageRotation;
    			}
    		}
    	}
    }
