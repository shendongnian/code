    public class accessManager : MonoBehaviour {
    
        public void OnAccessToken(string accessToken)
        {
            Debug.Log("Message Received!!!! :" + accessToken);
        }
    }
