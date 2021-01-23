	using Common.PCL;
	namespace Common.Shared
	{
		public class AutofacModule : Module
		{
			protected override void Load(ContainerBuilder builder)
			{
				builder.RegisterType<NetSpecificFactory>().As<INetSpecificFactory>();
			}
		}
	}
