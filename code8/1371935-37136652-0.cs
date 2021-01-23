    public class Topic : MonoBehaviour
    {
        
        public ToggleGroup Topiz;
          Toggle maybe1;
    	// Use this for initialization
    	void Start () 
        {
            
    	}
    
     
    	// Update is called once per frame
    	void Update () 
        {
            maybe1 = Topiz.ActiveToggles().FirstOrDefault();
    	}
        
    }
