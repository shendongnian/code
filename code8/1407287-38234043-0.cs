    public int sliderValue;
    
    void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            sliderValue += 1;
        }
        if (Input.GetMouseButtonDown(1))
        {
            sliderValue -= 1;
        }
    }
