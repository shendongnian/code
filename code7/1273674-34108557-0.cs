    public class MyBehavior : MonoBehaviour {
    	
        Vector3 lastPosition = new Vector3();
    
    	void Update () {
            Vector3 position = new Vector3();
            if (position != lastPosition)
            {
                OnPositionChange();
                lastPosition = position;
            }
            else
            {
                lastPosition = position;
            }
    	}
    
        public virtual void OnPositionChange(){}
    }
