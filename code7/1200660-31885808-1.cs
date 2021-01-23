	class ScoreClass
	{
		private List<CarCollision> collisions = new List<CarCollision>();
		
		public void AddCollision(string one, string two, ContactPoint contactPoint)
		{
			if(!collisions.Any(i => 
				i.victimOne == one && i.victimTwo == two
				|| i.victimTwo == one && i.victimOne == two))
			{
				collisions.Add(new CarCollision(one, two));
				
				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.position = contactPoint.point;
			}
		}
		
		public void RemoveCollision(string one, string two)
		{
			collisions.RemoveAll(i => 
				i.victimOne == one && i.victimTwo == two
				|| i.victimTwo == one && i.victimOne == two);
		}
	}
