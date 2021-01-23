	using Microsoft.Practices.Unity;
	using Prism.Unity;
	using PrismUnityApp2.Views;
	using System.Windows;
	
	namespace PrismUnityApp2
	{
		class Bootstrapper : UnityBootstrapper
		{
			protected override DependencyObject CreateShell()
			{
				return Container.Resolve<MainWindow>();
			}
	
			protected override void InitializeShell()
			{
				Application.Current.MainWindow.Show();
			}
		}
	}
