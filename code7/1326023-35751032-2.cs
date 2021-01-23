    public GameObject Targetposition;
    public bool camera_move_enabled;
    void Update () {
      if(camera_move_enabled){
           Maincamera.transform.position = Vector3.Lerp (transform.position, Targetposition.transform.position, speed * Time.deltaTime);
           Maincamera.transform.rotation = Quaternion.Lerp (transform.rotation, Targetposition.transform.rotation, speed * Time.deltaTime);
      }
    }
    public void UserClickedCameraResetButton()
    {
        Targetposition.transform.position = new Vector3(106, 68, 15);
        Targetposition.transform.rotation = new Vector4(40, 145, 0);
        camera_move_enabled = true;
    }
