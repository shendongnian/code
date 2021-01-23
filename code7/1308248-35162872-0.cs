    using System.Linq;	
    
    ...
	protected GameObject[] GetOverLap(GameType gameType){
		List<Collider> colliders = new List<Collider>();
		List<GameObject> gameObjects = new List<GameObject>();
		if (gameType == GameType._3D)
			colliders = Physics.OverlapSphere(transform.position, radius, layer).ToList();
		else if (gameType == GameType._2D)
			colliders = Physics2D.OverlapCircleAll(transform.position, radius, layer).ToList();
		foreach (Collider c in colliders)
			gameObjects.Add (c.gameObject);
		return gameObjects.ToArray();
	}
