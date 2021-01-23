    class CharacterSelector : Selector
    {
        Ray ray;    
        RaycastHit2D hit;   
    
        public void Start()
        {
            
        }
    
        void Update()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            onHover(ray, hit); 
    
            if (Input.GetMouseButtonDown(0))
            {                               
                selectCharacter();
            }
        }                   
    }
    
