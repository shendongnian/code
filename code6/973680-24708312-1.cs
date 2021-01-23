    List <Kiwi> kiwis;
    Vector2 playerPosition;
    Texture2D kiwiTexture;
    Initialize ()
    {
         this.kiwis = new Kiwi ();
         // Add some kiwi to collection
    }
    
    LoadContent ()
    {
         this.kiwiTexture = Content.Load <Texture2D> (...);
    }
    
    Update (GameTime pGameTime)
    {
         if (! this.isGameOwer)
         {
             // Update playerPosition
             playerPosition = ...
            
             // Then check collisions
             for (int i = 0; i <this.Kiwis.Count ;)
             {
                 if (this.Kiwis [i]. Intersect (playerPosition))
                 {
                     this.Kiwis.RemoveAt (i);
                     / / Add points to score or whatever else ...
                 }
                 else
                 {
                     i + +;
                 }
             }
            
             if (this.Kiwis.Count == 0)
             {
                 // All kiwis colelcted - end of game
                 this.isGameOwer = true;
             }
         }
    }
    
    Draw (GameTime pGameTime)
    {
         if (! this.isGameOwer)
         {
             this.spritebatch.Begin ();
            
             // Draw kiwis
             for (int i = 0; i <this.Kiwis.Count ;)
             {
                 Vector2 kiwiDrawPosition = new Vector2 (
                     this.Kiwis [i]. position.X - kiwiTexture.Width * 0.5f,
                     this.Kiwis [i]. position.Y - kiwiTexture.Height * 0.5f);
                 this.spritebatch (
                     this.kiwiTexture,
                     kiwiDrawPosition,
                     Color.White);
             }
            
             // Draw player
             ...
            
             this.spritebatch.end ()
         }
    }
