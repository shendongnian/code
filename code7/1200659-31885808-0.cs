	class CarCollision
	{
		public string victimOne;
		public string victimTwo;
		
		public CarCollision(string VictimOne, string VictimTwo)
		{
			victimOne = VictimOne;
			victimTwo = VictimTwo;
		}
	}
	
...
	void OnCollisionEnter (Collision col)
	{
		masterList.AddCollission(this.name, col.gameObject.name, collision.contacts [0]);
	}
	
	void OnCollisionExit (Collision col)
	{
		masterList.RemoveCollision(this.name, col.gameObject.name);
	}
	
