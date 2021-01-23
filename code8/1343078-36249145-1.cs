	public class InteractionManager : IInteractionManager
	{
		private readonly IMainClass mainClass;
		private readonly ISubClass subClass;
		public InteractionManager(
			IMainClass mainClass,
			ISubClass subClass)
		{
			this.mainClass = mainClass;
			this.subClass = subClass;
		}
		
		public void DoStuff()
		{
			this.mainClass.DoStuff(this.subClass);
		}
	}
	public class MainClass : IMainClass
	{
		public void DoStuff(ISubclass subclass)
		{
			// do something with transient subclass
		}
	}
	public class SubClass : ISubClass
	{ }
