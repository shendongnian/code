    public Transform gameobject1;
    public Transform gameobject2;
    public ParticleSystem particules;
    public float distance;
    
    //We grab the particle system in the start function
    void Start()
    {
        particules = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        //You have to keep checking for the Distance
        //if you want the particle system to play the moment distance goes below 20 
        //so we set our distance variable in the Update function.
        distance = Vector3.Distance(gameobject1.position, gameobject2.position);
        
        //if the objects are getting far from each other , use (distance >= 20)
        if(distance <= 20) 
        {
            particules.Play();
        }
    }
