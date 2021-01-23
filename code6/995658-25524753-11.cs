	class IocConfiguration : NinjectModule
	{
		public override void Load()
		{
			Bind<IStorage>().To<Storage>().InSingletonScope(); // Reuse same storage every time
			Bind<UserControlViewModel>().ToSelf().InTransientScope(); // Create new instance every time
		}
	}
