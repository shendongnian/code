    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    
    			var file1 = @"C:\Program Files (x86)\Electronic Arts\Crysis 3\Bin32\Crysis3.exe"; // 26MB
    			var file2 = @"C:\Program Files (x86)\Electronic Arts\Crysis 3\Bin32\d3dcompiler_46.dll"; // 3MB
    			List<string> files = new List<string> { file1, file2 };
    
    			var sw = System.Diagnostics.Stopwatch.StartNew();
    
    			// Prepare array of counters for the bytes
    			var nFiles = files.Count;
    			int[][] count = new int[nFiles][];
    			for (int i = 0; i < nFiles; i++)
    			{
    				count[i] = new int[256];
    			}
    
    			// Get the counts of bytes in each file
    			int bufLen = 32768;
    			byte[] buffer = new byte[bufLen];
    
    			int bytesRead;
    
    			for (int fileNum = 0; fileNum < nFiles; fileNum++)
    			{
    				using (var sr = new FileStream(files[fileNum], FileMode.Open, FileAccess.Read))
    				{
    					bytesRead = bufLen;
    					while (bytesRead > 0)
    					{
    						bytesRead = sr.Read(buffer, 0, bufLen);
    						for (int i = 0; i < bytesRead; i++)
    						{
    							count[fileNum][buffer[i]]++;
    						}
    					}
    				}
    			}
    
    			// Find which bytes are in any of the files or in all the files
    			var inAny = new List<byte>(); // union
    			var inAll = new List<byte>(); // intersect
    
    			for (int i = 0; i < 256; i++)
    			{
    				Boolean all = true;
    				for (int fileNum = 0; fileNum < nFiles; fileNum++)
    				{
    					if (count[fileNum][i] > 0)
    					{
    						if (!inAny.Contains((byte)i)) // avoid adding same value more than once
    						{
    							inAny.Add((byte)i);
    						}
    					}
    					else
    					{
    						all = false;
    					}
    				};
    
    				if (all)
    				{
    					inAll.Add((byte)i);
    				};
    
    			}
    
    			sw.Stop();
    
    			Console.WriteLine(sw.ElapsedMilliseconds);
    
    			// Display the results
    			Console.WriteLine("Union: " + string.Join(",", inAny.Select(x => x.ToString("X2"))));
    			Console.WriteLine();
    			Console.WriteLine("Intersect: " + string.Join(",", inAll.Select(x => x.ToString("X2"))));
    			Console.WriteLine();
    
    			// Compare to using LINQ.
    			// N/B. Will need adjustments for more than two files.
    
    			var srcBytes1 = File.ReadAllBytes(file1);
    			var srcBytes2 = File.ReadAllBytes(file2);
    
     			sw.Restart();
    
   			    var intersect = srcBytes1.Intersect(srcBytes2).ToArray().OrderBy(x => x);
    			var union = srcBytes1.Union(srcBytes2).ToArray().OrderBy(x => x);
    
    			Console.WriteLine(sw.ElapsedMilliseconds);
    
    			Console.WriteLine("Union: " + String.Join(",", union.Select(x => x.ToString("X2"))));
    			Console.WriteLine();
    			Console.WriteLine("Intersect: " + String.Join(",", intersect.Select(x => x.ToString("X2"))));
    
    			Console.ReadLine();
    
    		}
    	}
    }
    
