	using System;
	using GalaSoft.MvvmLight;
	using GalaSoft.MvvmLight.Threading;
	 
	namespace MvvmLight.Helpers
	{
		public class DesignAwareDispatcherHelper
		{
			public static void CheckDesignModeInvokeOnUI(Action action)
			{
				if (action == null)
				{
					return;
				}
				if (ViewModelBase.IsInDesignModeStatic)
				{
					action();
				}
				else
				{
					DispatcherHelper.CheckBeginInvokeOnUI(action);
				}
			}
		}
	}
