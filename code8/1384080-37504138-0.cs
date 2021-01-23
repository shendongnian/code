    Color backgroundColor = Color.CornflowerBlue;
    protected override void Update(GameTime gameTime)
	{    
		if (player.Bounds.Intersects(teleportObj.Bounds))
		{
			backgroundColor = Color.SlateGray;
			player.Position = new Vector2(172, 0); 
			MediaPlayer.Play(dungeonSong);
			MediaPlayer.IsRepeating = true;
		}
        else backgroundColor = Color.CornflowerBlue; 
	}
    protected override void Draw(SpriteBatch spriteBatch)
	{    
		GraphicsDevice.Clear(backgroundColor);
        *draw other stuff*
	}
