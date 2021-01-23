    using System;
    using System.Xml.Serialization;
    using System.IO;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var shape = new Shape { XPos = 4, YPos = 5 };
    		Console.WriteLine(Serialize(shape));
    		Console.WriteLine();
    		
    		var circle = new Circle { XPos = 1, YPos = 2, Radius = 3 };
    		Console.WriteLine(Serialize(circle));
    		Console.WriteLine();
    		
    		var square = new Square { XPos = 2, YPos = 1, Side = 5 };
    		Console.WriteLine(Serialize(square));
    		Console.WriteLine();
    	}
    			   
    	public static string Serialize(Shape objectToSerialize)
    	{
    		XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shape));
    		StringWriter textWriter = new StringWriter();
    	
    		xmlSerializer.Serialize(textWriter, objectToSerialize);
    		return textWriter.ToString();
    	}
    	
    	[XmlInclude(typeof(Circle))]
    	[XmlInclude(typeof(Square))]
    	public class Shape
    	{
    		public int XPos { get; set; }
    		public int YPos { get; set; }
    	}
    	
    	public class Circle : Shape
    	{
    	   public int Radius { get; set; }
    	}
    	
    	public class Square : Shape
    	{
    		public int Side { get; set; }
    	}
    }
