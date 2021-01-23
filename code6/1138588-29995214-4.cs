	class sharks:Sprite
	{
		public const float SharkVision = 500f;
		...
		public void Update(float elapsed, Vector2 playerLoc)
		{
			if ((playerLoc - location).Length() < SharkVision) 
				Accelerate(playerLoc - location);
			base.Update(elapsed);
		}
	}
