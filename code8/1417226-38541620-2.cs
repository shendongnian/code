    public class Test : MonoBehaviour
    {
        UpdateSubscriber updateSUBSCR;
    
        void Start()
        {
            updateSUBSCR = GameObject.Find("UpdateSUBSCR").GetComponent<UpdateSubscriber>();
        }
    
        void Update()
        {
            updateSUBSCR.callUpdateFuncs();
        }
    }
