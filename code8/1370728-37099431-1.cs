    public Weapon : MonoBehviour
    {
        public string name; //set these in the inspector for each weapon
        public float damage;
        //etc
    
        // in Unity you use the Start method for mono behaviours. NOT the constructor method
        void Start()
        {
            //Do things when the object is created
        }
    }
