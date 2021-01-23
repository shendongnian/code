    public class DataHolder : MonoBehaviour
    {
    public int someData;
    public static DataHolder holder; 
     
    void Awake()
    {
    if (holder == null)
            {
                DontDestroyOnLoad(gameObject);
                holder = this;
    
            }
            else if (holder != this)
            {
                Destroy(gameObject);
    
            }
        }
    
    }
