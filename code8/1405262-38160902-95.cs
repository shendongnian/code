    public void OnMouseDown()
     {
     manager.SpawnNewObstacle(transform.position);
     Destroy(gameObject);
     }
