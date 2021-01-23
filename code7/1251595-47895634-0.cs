    namespace NiftyStuff {
        public static class With {
			public static void with<T>(Action<T> proc) where T : GameObj {
				var typeName = typeof(T).Name;
				foreach (var item in GameObj.AllOf(typeName)) { proc((T)item); }
			}
		}
		public class GameObj {
			private static Dictionary<string, List<GameObj>> All = new Dictionary<string, List<GameObj>>();
			public static List<GameObj> AllOf(string name) {
				return All.ContainsKey(name) ? All[name] : null;
			}
			public static void Add(GameObj foo) {
				string typeName = foo.GetType().Name;
				List<GameObj> foos = All.ContainsKey(typeName) ? All[typeName] : (All[typeName] = new List<GameObj>());
				foos.Add(foo);
			}
			public float x, y, angle;
			public GameObj() { x = y = angle = 0; }
			public void Destroy() { AllOf(GetType().Name)?.Remove(this); }
		}
		public class Enemy : GameObj {
			public float maxHealth, curHealth;
			public Enemy() : base() { maxHealth = curHealth = 300; }
			public Enemy(float health) : base() { maxHealth = curHealth = health; }
			public bool Damage(float amt) {
				if (curHealth > 0) {
					curHealth -= amt;
					return curHealth <= 0;
				}
				return false;
			}
		}
		public class Pumpkin : GameObj {
			public bool exists = false;
			public Pumpkin() : base() { exists = true; }
			public bool LookAt() { return (exists = !exists); }
		}
	}
