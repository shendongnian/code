	class CarCollision
	{
		public string[] victims;
		
		public CarCollision(params string[] Victims)
		{
			victims = Victims;
		}
	}
	
...
	void OnCollisionEnter (Collision col)
	{
		masterList.AddCollission(collision.contacts [0], this.name, col.gameObject.name);
	}
	
	void OnCollisionExit (Collision col)
	{
		masterList.RemoveCollision(this.name, col.gameObject.name);
	}
	
