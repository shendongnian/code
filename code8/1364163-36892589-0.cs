     public void Update(Vector2 playerPosition)
     {
       if(position.X <0)
       {
           position.X = 0;
       }
       if(position.Y <0)
       {
           position.Y = 0;
       }
       viewMatrix = Matrix.CreateTranslation(new Vector3(-playerPosition.X, -playerPosition.Y, 0.0f));
    }
    
