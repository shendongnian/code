    using System;
    public class Program
    {
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
        public override void Copy(Car updatedFord)  //override,.
        {
            base.Copy(updatedFord);
            if(updatedFord is Ford)
                StickerCount = ((Ford)updatedFord).StickerCount;
        }
    }
    public static void Main()
    {
        Car car1 = new Ford { Colour = "Red", StickerCount = 1 };
        Car car2 = new Ford { Colour = "Blue", StickerCount = 666 };
        
        car1.Copy(car2);
        Console.WriteLine("Result should be blue: " + car1.Colour);
        Console.WriteLine("Result should be 666: " + ((Ford)car1).StickerCount);
        //another way with keeping your initial implementation
        Car car3 = new Ford { Colour = "Black", StickerCount = 33 };
        ((dynamic) car3).Copy(car2);    //invokek polymorphic behaviour
        Console.WriteLine("Result should be 666: " + ((Ford)car3).StickerCount);
        }
    }
