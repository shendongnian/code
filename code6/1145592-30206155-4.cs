    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Console.WriteLine("Time per run was: " + SimpleTest());
    		}
    		
    		const int Runs = 10;
    		const int Width = 5000;
    		const int Height = 5000;
    		const int Size = Width * Height;
    		
    		
    		static int[] Input = Enumerable.Range(0, Size).ToArray();
    		static int[] Output = new int[Size * 2];
    		
    		static float SimpleTest()
    		{
    			// Removing those 2 lines and using the static arrays instead give substantially slower performance, nearly half the speed!
    			//int[] Input = Enumerable.Range(0, Size).ToArray();
    			//int[] Output = new int[Size * 2];
    			
    			Stopwatch sw = new Stopwatch();
    			sw.Start();
    			
    			for (int run = 0; run < Runs; run++)
    			{
    				int InputIndex = 0;
    				for (int x = 0; x < Width; x++)
    				{
    					for (int y = 0; y < Height; y++)
    					{
    						int pixel = Input[InputIndex];
    						var OutputIndex = InputIndex * 2;
    						Output[OutputIndex] = pixel;
    						Output[OutputIndex + 1] = pixel;
    						InputIndex++;
    					}
    				}
    			}
    			sw.Stop();
    			return (sw.ElapsedMilliseconds / (float)Runs);
    		}
    	}
    }
