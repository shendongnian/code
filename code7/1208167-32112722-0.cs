	public abstract class Car
    {
		public string Colour { get; set; }
		
        public virtual void Copy(Car car)
        {
            Colour = car.Colour;
        }
    }
    
    public class Ford : Car
    {
		public int StickerCount { get; set; }
		
        public override void Copy(Car car) 
        {
            base.Copy(car);
            Ford ford = car as Ford;
            if (ford != null)
                StickerCount = ford.StickerCount;    
        }
    }
    
  	public static void Main()
	{
		Car car1 = new Ford { Colour = "Red", StickerCount = 1 };
		Car car2 = new Ford { Colour = "Blue", StickerCount = 666 };
		
        // if Copy is not virtual, Car.Copy will be called here instead of Ford.Copy!
		car1.Copy(car2);
		
		Console.WriteLine("Result should be blue: " + car1.Colour);
		Console.WriteLine("Result should be 666: " + ((Ford)car1).StickerCount);
	}
