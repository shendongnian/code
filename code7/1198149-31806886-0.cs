    public class gameVariables: MonoBehaviour
    {
    public int Lives;
    public bool Creation = false;
    
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    
    void Start()
    {
        if(Creation)
        {
            Lives = 3;
        }
    }
    
    public void Updatelives(int value)
    {
         Lives += value; //value can be -1 or what not, al
    }
    }
