	private Action<GameTime> updateGameTime = null;
	
	public void Initialize()
	{
	    component = new Component();
	
		Observable
			.FromEvent<GameTime>(a => updateGameTime += a, a => updateGameTime -= a)
			.Subscribe((gameTime) => component.Update(gameTime));
	}
	
	public void Update(GameTime gameTime)
	{
	    updateGameTime(gameTime);
	}
