    public class Player : MonoBehaviour
    {
    
    void Start()
    {
        Utils.WaitAndExecute(this , 5, callback);
    }
    public void callback()
    {
        // blah blah blah
    }
    
    }
    public class Utils
    {
    public void WaitAndExecute(MonoBehaviour objectToRun , float time, Action callback)
    {
        // ...
        objectToRun.StartCoroutine(...);
        // ...
    }
    }
