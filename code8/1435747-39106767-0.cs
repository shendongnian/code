    interface IDiffable<T>
	{
		string Diff(IDiffable<T> obj);
	}
	class DiffA : IDiffable<DiffA>
	{
		public string Diff(IDiffable<DiffA> obj)
		{
			return "Diffable A";
		}
	}
	class DiffB : IDiffable<DiffB>
	{
		public string Diff(IDiffable<DiffB> obj)
		{
			return "Diffable B";
		}
	}
