    void Update () {
        if (Input.GetKey ("escape")) {
            Application.Quit();
        }
        // calculate new speed
        if (Input.GetKey ("w")) {
            speed += acceleration*Time.deltaTime;
        }
        else if (Input.GetKey ("s")) {
            speed -= acceleration*Time.deltaTime;
        }
        // apply speed
        transform.Rotate(Vector3.up, speed*Time.deltaTime);
    }
