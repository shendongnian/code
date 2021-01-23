	using System;
	using System.IO;
	using System.Linq;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				var buffer = new byte[1024];
				int pos = 0; 
			
				using (var fileIn = new FileStream(@"c:\test.txt", FileMode.Open, FileAccess.Read))
				using (var fileOut = new FileStream(@"c:\test.txt.binary", FileMode.Create, FileAccess.Write))
					while((pos = fileIn.Read(buffer,0,buffer.Length)) > 0)
						foreach (var value in buffer.Take(pos).Select(x => Convert.ToString(x, 2).PadLeft(8, '0')))
							fileOut.Write(value.Select(x => (byte)x).ToArray(), 0, 8);
			}
		}
	}
