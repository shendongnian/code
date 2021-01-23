    public class Test: MonoBehaviour
    {
    	public Camera_Container [] camPos;
    }
    
    [System.Serializable]
    public class Camera_Container{
    	public Camera_Positioning [] camPos;
    }
    
    [System.Serializable]
    public class Camera_Positioning
    {
    	public Transform cameraPosition;
    	public Transform cameraLook;
    	public int story;
    }
