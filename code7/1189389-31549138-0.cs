    float distance = 10f;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Shoot(ray.GetPoint(distance));
    }
    public void Shoot(float point)
    {
        // shoot from camera location to point here
    }
