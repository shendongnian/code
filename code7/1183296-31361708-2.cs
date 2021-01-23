	class Program
	{
		static void Main(string[] args)
		{
			var proc = Process.GetProcessesByName("explorer").FirstOrDefault();
			Injector.Launch(proc.MainWindowHandle, typeof(Loader).Assembly.Location, typeof(Loader).FullName, "Inject");
		}
	}
	public class Loader
	{
		public static void Inject()
		{
			MessageBox.Show("Hello");
			Task.Run(() =>
			{
				Thread.Sleep(3000);
				MessageBox.Show("Hello again");
				Thread.Sleep(5000);
				MessageBox.Show("Hello again again");
			});
		}
	}
