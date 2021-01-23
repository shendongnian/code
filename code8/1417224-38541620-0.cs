    public class ManagedUpdateBehavior : MonoBehaviour
    {
        UpdateSubscriber updateSUBSCR;
    
        //Add it self to the List
        void Start()
        {
            updateSUBSCR = GameObject.Find("UpdateSUBSCR").GetComponent<UpdateSubscriber>();
            updateSUBSCR.addManagedUpdateBehavior(this);
        }
    
        //Remove it self from the List
        void OnDestroy()
        {
            updateSUBSCR.removeManagedUpdateBehavior(this);
        }
    
        public void UpdateMe()
        {
            // some logic
            Debug.Log("Update from: " + gameObject.name);
        }
    }
