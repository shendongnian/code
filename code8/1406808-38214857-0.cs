	abstract class BaseItem 
	{
		public abstract int Calculate();
	}
	
	class ItemA : BaseItem
	{
		public override int Calculate()
		{
			return 0 + 1;
		}
	}
	
	class ItemB : BaseItem
	{
		public override int Calculate()
		{
			return 1 + 1;
		}
	}
	
	void Main()
	{
		BaseItem a = new ItemA();
		int result = a.Calculate();
	}
