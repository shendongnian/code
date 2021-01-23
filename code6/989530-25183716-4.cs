	using System;
	namespace zPlayGround
	{
		class Program
		{
			static void Main()
			{
				Console.WriteLine("Manually calling newClass.Dispose();");
				var newClass = new DisposableClass();
				try
				{
				}
				finally
				{
					newClass.Dispose();
				}
				Console.WriteLine("Now wrapped in using...");
				using (var usingClass = new DisposableClass())
				{
					
				}
				Console.WriteLine("Manually calling IDisposable.Dispose();");
				var demoClass = new DisposableClass();
				try
				{
				}
				finally
				{
					((IDisposable)newClass).Dispose();
				}
				Console.ReadKey();
			}
		}
		internal class DisposableClass : IDisposable
		{
			public void Dispose()
			{
				Console.WriteLine("public void Dispose() being called.\r\n");
			}
			void IDisposable.Dispose()
			{
				Console.WriteLine("void IDisposable.Dispose() being called.\r\n");
			}
		}
	}
