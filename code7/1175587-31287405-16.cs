	namespace SampleWeb
	{
		partial class ModuleProvider
		{
			protected override void Setup()
			{
				AddModule<SampleLogger.DefaultLoggerModule>();
			}
		}
	}
