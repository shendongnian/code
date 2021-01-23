	class ScoreClass
	{
		private List<CarCollision> collisions = new List<CarCollision>();
		
		public void AddCollision(ContactPoint contactPoint, params string[] victims)
		{
			if(!collisions.Any(i => 
				i.victims.All(v => victims.Contains(v)))
			{
				collisions.Add(new CarCollision(victims));
				
				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.position = contactPoint.point;
			}
		}
		
		public void RemoveCollision(params string[] victims)
		{
			collisions.RemoveAll(i => 
				i.victims.All(v => victims.Contains(v)));
		}
	}
