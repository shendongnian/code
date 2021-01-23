    class GameObject
    {
       DateTime lastUpdate;
    
       void Update()
       {
          TimeSpan deltaTime = DateTime.Now - lastUpdate;
    
          ...
       }
    }
