    public class LoadSaveManager : MonoBehaviour
    {
        public int IsFirst; 
        void Start ()
        {
            IsFirst = PlayerPrefs.GetInt("IsFirst") ;
            if (IsFirst == 0) 
            {
                //Do stuff on the first time
                Debug.Log("first run");
                PlayerPrefs.SetInt("IsFirst", 1);
            } else { 
                //Do stuff other times
                Debug.Log("welcome again!");
            }
        }
    }
