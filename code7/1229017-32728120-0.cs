    using System;
    using System.Drawing;
    
    namespace JpegTest
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			try
    			{
    				var image = new Bitmap(@"test.jpeg", true);
    				Console.WriteLine("Width: {0}", image.Width);
    				Console.WriteLine("Height: {0}", image.Height);
    			}
    			catch (ArgumentException)
    			{
    				Console.WriteLine("There was an error." + "Check the path to the image file.");
    			}
    		}
    	}
    }
