    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    
    namespace Samples
    {
    	public static class Algorithms
    	{
    		public static IEnumerable<string> GetCombinationsA(this char[][] input)
    		{
    			var result = new char[input.Length];
    			var indices = new int[input.Length];
    			for (int pos = 0, index = 0; ;)
    			{
    				for (; pos < input.Length; pos++, index = 0)
    				{
    					indices[pos] = index;
    					result[pos] = input[pos][index];
    				}
    				yield return new string(result);
    				do
    				{
    					if (pos == 0) yield break;
    					index = indices[--pos] + 1;
    				}
    				while (index >= input[pos].Length);
    			}
    		}
    
    		public static IEnumerable<string> GetCombinationsB(this char[][] input)
    		{
    			Func<IEnumerable<IEnumerable<char>>, IEnumerable<IEnumerable<char>>> combine = null;
    			combine = css =>
    						from c in css.First()
    						from cs in css.Skip(1).Any()
    							? combine(css.Skip(1))
    							: new[] { Enumerable.Empty<char>() }
    						select new[] { c }.Concat(cs);
    			return combine(input).Select(c => String.Join("", c));
    		}
    	}
    
    	class Program
    	{
    		class Algorithm
    		{
    			public string Name;
    			public Func<char[][], IEnumerable<string>> Func;
    		}
    
    		static void Main(string[] args)
    		{
    			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    			Algorithm[] algorithms =
    			{
    				new Algorithm { Name = "A", Func = Algorithms.GetCombinationsA },
    				new Algorithm { Name = "B", Func = Algorithms.GetCombinationsB },
    			};
    			char[][] myArray = { new char[] {'A', 'B'}, new char[] {'C', 'D'}, new char[] {'E', 'F'} };
    			foreach (var algo in algorithms)
    				algo.Func(myArray);
    			var chars = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToArray();
    			for (int n = 2; n < 7; n++)
    			{
    				var input = Enumerable.Range(0, n).Select(_ => chars).ToArray();
    				foreach (var algo in algorithms)
    					Test(algo, input);
    				Console.WriteLine();
    			}
    			Console.WriteLine("Done.");
    			Console.ReadLine();
    		}
    
    		static void Test(Algorithm algo, char[][] input)
    		{
    			GC.Collect(); GC.WaitForPendingFinalizers();
    			GC.Collect(); GC.WaitForPendingFinalizers();
    			var totalMem = GC.GetTotalMemory(false);
    			var timer = Stopwatch.StartNew();
    			long count = 0;
    			foreach (var comb in algo.Func(input)) count++;
    			timer.Stop();
    			totalMem = GC.GetTotalMemory(false) - totalMem;
    			Console.WriteLine($"{algo.Name}: N={input.Length} Count={count,12:n0} Time={timer.Elapsed} Memory={totalMem / 1024,7:n0}K");
    		}
    	}
    }
