    using MvvmCross.Core;
    using MvvmCross.Core.Platform;
    using MvvmCross.Platform.IoC;
    using MvvmCross.Platform.Platform;
    
    namespace MvvmCross.Test.Core
    {
    	public class BaseMvvmCrossTest
    	{
    		static BaseMvvmCrossTest()
    		{
    			if (MvxSimpleIoCContainer.Instance == null)
    			{
    				MvxSingletonCache.Initialize();
    				MvxSimpleIoCContainer.Initialize();
    
    				MvxSimpleIoCContainer.Instance.RegisterSingleton(MvxSimpleIoCContainer.Instance);
    				MvxSimpleIoCContainer.Instance.RegisterSingleton<IMvxTrace>(new TestTrace());
    				MvxSimpleIoCContainer.Instance.RegisterSingleton<IMvxSettings>(new MvxSettings());
    
    				MvxTrace.Initialize();
    			}
    		}
    	}
    }
