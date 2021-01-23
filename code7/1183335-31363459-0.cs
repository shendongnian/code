	public class Entity {
		// other code
		
		public Entity(string Type, string Spawnzone, string _Class, int Defaultlevel, int Maxlevel, string trait, int str, int agi, int dex, int hel, int man) {
			// move setEntity code here.
		}
		
		// other code
	}
	public class Enemy {
		// other code
		public Enemy(string[] Droplist, int Defaultgold, string Weaknesses, string Resistances, string[] Taunts, string Aggro, string Critchance, string Threshold, string Name, Entity entity) {
				this.entity = entity;
				droplist = Droplist;
				defaultgold = Defaultgold;
				weaknesses = Weaknesses;
				resistances = Resistances;
				taunts = Taunts;
				aggro = Aggro;
				critchance = Critchance;
				threshold = Threshold;
		}
		
		// other code
	}	
