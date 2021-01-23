    using System.Linq;	
    
    ...
	protected GameObject[] GetOverLap(GameType gameType){
		List<Component> collComponents = new List<Component>();
		List<GameObject> gameObjects = new List<GameObject>();
		if (gameType == GameType._3D)
			collComponents = Physics.OverlapSphere(transform.position, radius, layer).Cast<UnityEngine.Component>().ToList();
		else if (gameType == GameType._2D)
			collComponents = Physics2D.OverlapCircleAll(transform.position, radius, layer).Cast<UnityEngine.Component>().ToList();
		foreach (Component c in collComponents)
			gameObjects.Add (c.gameObject);
		return gameObjects.ToArray();
	}
