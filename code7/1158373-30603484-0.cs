    void Update ()
    {
        transform.Rotate(Vector3.up,speed * Time.deltaTime);
        if (Input.GetKey ("escape")) {
            Application.Quit();
        }
        if (Input.GetKey ("w")) {
            transform.Rotate(Vector3.up,speed++);
        }
        if (Input.GetKey ("s")) {
            transform.Rotate(Vector3.up,speed--);
        }
    }
