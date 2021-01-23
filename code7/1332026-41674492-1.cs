    /**Class Attributes**/
    TimeSpan t;
    /**End**/
    for (int i = 0; i < powerballs.Count; i++)
    {
        rectangle3 = new Rectangle((int)powerballs[i].Position.X,
            (int)powerballs[i].Position.Y,
            powerballs[i].Width,
            powerballs[i].Height);
    
        // Determine if the two objects collided with each other
        if (rectangle1.Intersects(rectangle3))
        {
            boost = true;
            powerballs[i].Active = false;
            //reset timer if collide, and intanciate them the first time\\
            t = new TimeSpan();
        }
        else
        {
            boost = false;
        }
        if (boost == true && t.Milliseconds <= 10000)
        {                   
                for (int j = 0; j < enemies.Count; j++)
                {
                    // Increased enemy speed variable
                    float newEnemySpeed = 30f;
    
                    // Setting increased speed to each enemy in the list 
                    enemies[j].SetNewMoveSpeed(newEnemySpeed);
                }
                //Increased Background speed variables
                int newBackgroundSpeed1 = -5;
                int newBackgroundSpeed2 = -10;
    
                // Setting increased Background speed
                bgLayer1.SetNewSpeed(newBackgroundSpeed1);
                bgLayer2.SetNewSpeed(newBackgroundSpeed2);;
                //increment Timer with the gameTime\\
                t+=gameTime.ElapsedGameTime;
        }
        else
        {
            for (int k = 0; k < enemies.Count; k++)
            {
                // Set emeny speed back to normal
                enemies[k].SetNewMoveSpeed(6f);
            }
            // Set background speed back to normal
            bgLayer1.SetNewSpeed(-1);
            bgLayer2.SetNewSpeed(-2);
        }
    }   
