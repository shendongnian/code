		public Vector3 Velocity;
		public Vector3 Position;
		public void Update(GameTime gameTime)
		{
			float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
			// Apply acceleration
			Vector3 acceleration = force / Mass;
			Velocity += acceleration * elapsed;
			// Apply psuedo drag
			Velocity *= DragFactor;
			// Apply velocity
			Position += Velocity * elapsed;
            .
            .
            .
