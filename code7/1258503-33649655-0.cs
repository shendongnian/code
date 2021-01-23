    public override void OpeningDoor() {
        Vector3 movement = new Vector3 (2.006f, 0.0f,1.793f);
        Vector3 rotate = new Vector3 (0.0f, 108.3f, 0.0f);
        transform.Translate (movement);
        transform.Rotate (rotate);
        toClose = true;
    }
    
    public override void ClosingDoor() {
        Debug.Log ("Closing Door");
        Vector3 movement = new Vector3 (-2.006f, 0.0f,-1.793f);
        Vector3 rotate = new Vector3 (0.0f, -108.3f, 0.0f);
        transform.Rotate (rotate);
        transform.Translate (movement);
        toClose = false; 
    }
