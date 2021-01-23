	public class Weapon
	{
		public DamageHandler damageHandler; //script that have all special rule functions
		public string weaponName;
		public int damage;
		public Action<int> specialRule; //this is the rule of interest
		public void DealDamage()
		{
			damageHandler = GetComponent<DamageHandler>();
			damageHandler.specialRule(damage); //I call the function with the name that is set in Weapon Class
		}        
	}
