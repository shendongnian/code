	public class Switch : IEnumerable<Switch.Case>
	{
		private List<Case> _list = new List<Case>();
	
		public void Add(Func<bool> condition, Action action)
		{
			_list.Add(new Case(condition, action));
		}
	
		IEnumerator<Case> IEnumerable<Case>.GetEnumerator()
		{
			return _list.GetEnumerator();
		}
	
		IEnumerator IEnumerable.GetEnumerator()
		{
			return _list.GetEnumerator();
		}
	
		public void Execute()
		{
			this
				.Where(c => c.Condition())
				.Select(c => c.Action)
				.FirstOrDefault()
				?.Invoke();
		}
	
		public sealed class Case
		{
			private readonly Func<bool> _condition;
			private readonly Action _action;
	
			public Func<bool> Condition { get { return _condition; } }
			public Action Action { get { return _action; } }
	
			public Case(Func<bool> condition, Action action)
			{
				_condition = condition;
				_action = action;
			}
		}
	}
