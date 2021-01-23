    using System;
    using System.IO;
    
    namespace ConsoleApplication2 {
    	class Program {
    		public static void Main(string[] args) {
    			if (args == null || args.Length == 0) {
    				Console.WriteLine("Error: please specify the file to read!");
    				Console.ReadKey();
    				return;
    			}
    
    			try {
    
    				StreamReader src = new StreamReader(args[0]);
    
    				while (!src.EndOfStream) {
    					string line = src.ReadLine();
    					Console.WriteLine(line);
    				}
    			} catch (Exception ex) {
    				Console.WriteLine("Error while reading the file! " + ex.ToString());
    			}
    
    			Console.ReadKey();
    		}
    	}
    }
