	protected override void Draw(GameTime gameTime)
	{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();   
			spriteBatch.Draw(danChar, charPosition, Color.White);
			
			// Assuming you've created/loaded an instance of the GameWorld class
            // called gameWorld in Initialize/LoadContent
			gameWorld.Draw(spriteBatch, gameTime, gameTile);
			spriteBatch.End();  // ends the spriteBatch call
			base.Draw(gameTime);
	}
