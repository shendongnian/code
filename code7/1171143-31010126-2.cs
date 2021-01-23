    //Add a atrubit count to your class:
    int count = 0;
    //Update method:
    protected override void Update(GameTime gameTime)
    {
        count++;//update count
        
        if(count % 1000 == 0){
            enemyspeed++;//update speed after 1000 updates
        }
        if(count % 75 == 0){//draw after 75 updates
            spriteBatch.Begin();
            spriteBatch.Draw(enemy, new Vector2(enemyloc, 450), Color.White);
            spriteBatch.End();
            enemyloc = enemyspawner.Next(500);
        }
        //do your other stuff
    }
