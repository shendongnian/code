    public Camera MyCamera; // The camera you want to follow the GameObject
    public GameObject ObjectToFollow; // What you want to follow
    private Vector3 CameraPos; // Variable that contains the Cameras x,y,z position
    void Start()
    {
        CameraPos = MyCamera.transform.position; // stores the Camera's position in the variable
    }
    // Update is called once per frame
    void Update () {
        CameraPos.x = ObjectToFollow.transform.position.x; // Change The X position on the camera variable to be the same as the ObjectToFollow X position
        MyCamera.transform.position = CameraPos; // Moves the Camera to the new position
    }
