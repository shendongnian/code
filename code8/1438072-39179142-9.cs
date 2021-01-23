    public class PlayerController: MonoBehaviour
    {
        public void OnGameObjectClicked(GameObject objClicked)
        {
            Debug.Log("There was a click from: "+objClicked.name);
            if (objClicked.CompareTag("right"))
            {
                //Your code
            }
            else if (objClicked.CompareTag("left"))
            {
                //Your code
            }
            else if (objClicked.CompareTag("up"))
            {
                //Your code
            }
        }
    }
