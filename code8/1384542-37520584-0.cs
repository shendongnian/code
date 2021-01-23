    GameObject playerCube; //this is reference to Player object
    bool playerEnter = false;
    bool playerLeft = false;
    
    void Start()
    {
         playerCube = Gameoject.Find("PlayerCube"); // here you put the name of your player object as a string. Exactly as it is in the hierarchy
    }
    void Update()
    {
    if(playerCube.transform.position == transform.position)
    {
          playerEnter = true; // this checks if player stepped on the cube 
    }
    if(playerCube.transform.position != transform.position && playerEnter == true && playerLeft == false) //checks if player left the cube
    {
     playerLeft = true; // we do this so the code below is executed only once
        gameObject.AddComponent<Rigidbody>(); // ads rigidbody to your basecube
        Destroy(gameObject, 1.0f); //destroys baseCube after one second
    }
