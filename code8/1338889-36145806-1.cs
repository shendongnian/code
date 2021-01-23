    public class Program
    {
    	public static void Main()
    	{
            Console.WriteLine("First Example");
            //first example
            Point p1 = new Point();
    		p1.store = new SomeClass();
    		p1.store.Name = "Jenish";
            p1.Name = "firstPoint";
            p1.X = 10;
            p1.Y = 20;
    
            Point p2 = p1;
    
            p2.Name = "secondPoint";
    		p2.store.Name = "Jenish2";
            p2.X = 40;
            p2.Y = 50;
    
            p1.Print(); //Prints - Name: firstPoint, X:10, Y:20
            p2.Print(); //Prints - Name: secondPoint, X:40, Y:50
    
            Console.ReadLine();
    	}
    }
    
    public struct Point
    {
    	
        public string Name;
        public int X;
        public int Y;
    	public SomeClass store;
    
        public void Print()
        {
    		Console.WriteLine("Name: {0}, X: {1}, Y: {2}, Name: {3}", this.Name.ToString(), this.X, this.Y, this.store.Name);
        }
    }
    
    public class SomeClass{
    	public string Name {get; set;}
    }
