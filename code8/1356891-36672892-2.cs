	public class GameWorld
	{
        // You may wish to move your gameTile definition into this class if it is the only
        // class that uses it, and handle the content loading for it in here.
        // e.g. if you're currently loading the texture in the LoadContent method in your game
        // class, create a LoadContent method here and pass in ContentManger as a parameter.
        // I've passed in the texture as a parameter to the Draw method in this example to
        // simplify as I'm not sure how you're managing your textures.
		public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Texture2D gameTile)
		{
			// loop below loads the 'grass' tiles only
			// assuming gameworld size of 770x450
			for (int i = 0; i < 770; i += 31) // adds 31 to i (per tile)
			{
				Vector2 position = new Vector2(i, 392); // places incrementation into vector position
				spriteBatch.Draw(gameTile, position, Color.White); // draws the tile each time
				if (i == 744)
				{
					i = i + 26; // fills last space between 744 and 770
					position = new Vector2(i, 392);
				}
				spriteBatch.Draw(gameTile, position, Color.White); 
			}
			// loop below loads the brick tiles only (ones without grass)	
		}
	}
