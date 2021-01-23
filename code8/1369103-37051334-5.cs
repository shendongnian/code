	protected override void LoadContent()
			{
				//SPLASH SCREEN
				ssm = new SplashScreenManager(@"Splash\Pictures", 3, 1, 3, Keys.Space);
			}
	protected override void Update(GameTime gameTime)
			{
				if (currentGameState == GameState.Initialize)
				{
					ssm.Update(gameTime);
					if (!ssm.Running)
						currentGameState = GameState.Menu;
				}
            }
	protected override void Draw(GameTime gameTime)
			{
				GraphicsDevice.Clear(Color.DeepSkyBlue);
				switch (currentGameState)
				{
					case GameState.Initialize:
						spriteBatch.Begin();
						ssm.Draw(spriteBatch);
						spriteBatch.End();
						break;
				}
			}
A note for SplashScreenManager's constructor: GContent.Textures(path);'s goal is to try to load all images from that folder. This function looks like this:
	public static           List<Texture2D>     Textures(string folderPath)
	{
		if (!folderPath.StartsWith(@"\")) folderPath = @"\" + folderPath;
		List<string> paths = Directory.GetFiles(Help.RootDir(Content.RootDirectory) + folderPath).ToList();
		List<Texture2D> images = new List<Texture2D>();
		foreach (string s in paths)
		{
			if (s.EndsWith(".xnb"))
				images.Add(Texture(s.Replace(Content.RootDirectory, "").Replace(".xnb", "")));
		}
		return images;
	}
Where, again, the Help.RootDir just returns the root directory, like this:
	public static string RootDir(string s)
	{
		return s.Substring(0, s.LastIndexOf(@"\"));
	}
This way you can have all splash images in one folder. Offcorse, it's up to you how you want to manage your resources. This is a realy simple way with some great functionality. Try testing it with old sony play station sound in the background and use these parameters for SSM: ssm = new SplashScreenManager(*your list of splash images*, 3, 1, 3). Looks and sounds great. Thumbs up if this helped you!
