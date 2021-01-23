    // in Obstacle.cs
    public void OnMouseDown()
    {
        manager.SpawnNewObstacle(transform.position);    // you might be able to actually pass the transform, but I'm not sure if it will get destroyed before used in the other function
        Destroy(gameObject);
    }
