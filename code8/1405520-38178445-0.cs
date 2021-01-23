	public void Initialize()
	{
		//updateSubject = new Subject<GameTime>();
		component = new Component();
		//updateSubject.Subscribe((gameTime) => component.Update(gameTime));
	}
	public void Update(GameTime gameTime)
	{
		//updateSubject.OnNext(gameTime);
		component.Update(gameTime)
	}
