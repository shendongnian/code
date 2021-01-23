	namespace SomeNS
	{
		using System.Diagnostics;
		using System.Windows.Forms;
		public static class SomeClass
		{
			static void SomeMethod()
			{
				Process process = Process.Start("child-app.exe");
				// YourDialog is your dialog implementation inheriting from System.Windows.Window
				YourDialog dlg = new YourDialog();
				dlg.Loaded += (sender, e) =>
				{
					process.WaitForInputIdle();
					Form window = (Form)Control.FromHandle(process.MainWindowHandle);
					// Do something with the child app's window
					dlg.Close();
				};
				dlg.ShowDialog();
			}
		}
	}
