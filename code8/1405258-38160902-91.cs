    public GameObject modelObstacle;
    void CreateObstacle()
     {
     GameObject nu = Instantiate(modelObstacle);
     obstacles.Add(nu);
     nu.name = "created dynamically, item " + obstacles.Length;
     nu.transform.position = ChoosePosition();
     }
