    using System;
    
    public class Test
    {
    	static int width;
    	static int height;
    	
        public static void Main()
        {
            Console.Write("Enter width of rectangle: ");
            width = int.Parse(Console.ReadLine()); 
            Console.Write("Enter height of rectangle: ");
            height = int.Parse(Console.ReadLine()); 
            Console.WriteLine();
            if(width > 5 && width <= 80 && height > 5 && height <= 20)
            {
                draw();
            }
            else
            {
                Console.WriteLine("Invalid entry!");
            }
    	}
    	
        static void draw()
        {
    		Console.WriteLine((float)width/(float)height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (IsBorder(x, y)  || IsDiagonal(x, y))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                   }
    
                } Console.WriteLine();
            }
    	}
    	
    	static bool IsBorder(int x, int y)
    	{
    		return x == 0 
                || x == width  
                || y == 0  
                || y == height  
                || x == width - 1  
                || y == height - 1;
    	}
    	
    	static bool IsDiagonal(int x, int y)
    	{
    		return width < height  
                ? IsDiagonalHigh(x, y)  
                : IsDiagonalWide(x,y);
    	}
    	
    	static bool IsDiagonalHigh(int x, int y)
    	{
    		var aspectRatio = (float)width / (float)height;
    		return x == (int)(y * aspectRatio) 
    			|| x == width - (int)(y * aspectRatio) - 1;
    	}
    	
    	static bool IsDiagonalWide(int x, int y)
    	{
    		var aspectRatio = (float)height / (float)width;
    		return y == (int)(x * aspectRatio)  
    			|| y == (int)((width - x - 1) * aspectRatio);
    	}
    	
    }
