	public class Spawner : MonoBehaviour {
		//only spawns, attached to some gameobject
		public GameObject prefabToSpawn;
		public GameObject Spawn() {
			//instantiate etc..
			GameObject newObject = Instantiate(prefabToSpawn);
			return newObject
		}
	}
	public class EnemyManager : MonoBehaviour {
		//attached to an empty gameObject
		public Spawner spawner;
		public Enemy CreateNewEnemy () {
			GameObject newEnemy = spawner.Spawn ();
			// add it to list of enemies or something
			//other stuff to do with managing enemies
		}
	}
	public class Navigator : MonoBehaviour {
		//Attached to Enemy prefab
		Destination currentDestination;
		public float changeDestinationTime;
		void Start() {
			currentDestination = //first place you want to go
			InvokeRepeating ("NewDestination", changeDestinationTime, changeDestinationTime);
		}
				
		void NewDestination() {
			currentDestination = // next place you want to go
		}
	}
