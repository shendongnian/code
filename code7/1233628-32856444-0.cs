	public class Holded
	{
		protected internal static Dictionary<string, int> _personHoldedIDs;
		internal string _person;
		public Holded(string person)
		{
			_person = person;
			if (_personHoldedIDs == null)
				_personHoldedIDs = new Dictionary<string, int>();
			if (!_personHoldedIDs.ContainsKey(_person))
				_personHoldedIDs.Add(_person, 0);
		}
	}
	public class Inventory : Holded
	{
		public Inventory(string person) : base(person) { }
		public void changeHoldedID()
		{
			_personHoldedIDs[_person] = 100;
		}
	}
	public class Equipment : Holded
	{
		public Equipment(string person) : base(person) { }
		public void writeHoldedID()
		{
            Console.WriteLine("Holded ID is: {0}!", _personHoldedIDs[_person]);
		}
	}
