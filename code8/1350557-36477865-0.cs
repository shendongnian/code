	public abstract class GameBehaviour : MonoBehaviour {
		private bool initialized = false;
		public void Initialize(GameState gameState)
		{
			initialized = true;
		}
	}
	public abstract class GameBehaviour<T> : GameBehaviour where T: GameBehaviour<T>
	{
		public static T Attach(GameObject parent, GameState gameState)
		{
			T behaviour = parent.AddComponent<T>();
			behaviour.Initialize(gameState);
			return behaviour;
		}
	}
	public class WorldManager: GameBehaviour<WorldManager> { ... }
	public class WorldRenderer: GameBehaviour<WorldRenderer> { ... }
	
