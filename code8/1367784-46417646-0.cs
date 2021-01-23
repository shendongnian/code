    void Update ()
        {
            OVRInput.Update(); // Call before checking the input
 
            if (OVRInput.Get(OVRInput.Button.DpadLeft)) {
                print("left button pressed");
            }
            if (OVRInput.Get(OVRInput.Button.DpadRight)) {
                print("right button pressed");
            }
            if (OVRInput.Get(OVRInput.Button.One)) {
                print("round button pressed");
            }
        }
