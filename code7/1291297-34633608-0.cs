    class GameObject
    {
       DateTime lastUpdate;
    
       void Update ()
       {
          TimeSpan timeDelta = DateTime.Now - lastUpdate;
    
          ...
       }
    }
