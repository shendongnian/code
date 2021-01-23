    private float lastClickTime;
    public float catchTime = 0.25f;
    void Update ()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(Time.time - lastClickTime < catchTime)
            {
                //double click
                print("Double click");
            }
            else
            {
                //normal click
            }
            lastClickTime = Time.time;
        }
    }
