    public class RepoNinjectModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IMyRepo>().To<MyRepo>();
		}
	}
