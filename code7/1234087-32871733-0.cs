    using System;
    using MySql.Data.MySqlClient;
    
    namespace TestApp
    {
    	internal class Program
    	{
    		private static void Main(string [] args)
    		{
    			Console.WriteLine("Hello world!");
    			var command = new MySqlCommand();
    			Console.WriteLine(command.ToString());
    		}
    	}
    }
