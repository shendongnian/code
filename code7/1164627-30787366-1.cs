    SpeedHolder speedHolder;
    public void Update()
    {
        transform.position += speedHolder.Speed * Time.deltaTime;
    }
