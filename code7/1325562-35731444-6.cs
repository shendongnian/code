    public class Mark {
    
    public GameObject InstantiatedGameObject;
    public Vector3 ControllerPosition;
    public Quaternion ControllerRotation;
    
    public Mark(GameObject o, Vector3 p, Quaternion r)
    {
        InstantiatedGameObject = o;
        ControllerPosition = p;
        ControllerRotation = r;
    }
