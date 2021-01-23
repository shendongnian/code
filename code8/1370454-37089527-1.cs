    using System;
    using ImpromptuInterface;
    using ImpromptuInterface.Dynamic;
    
    namespace Example
    {
    	public interface IEngine
    	{
    		void Foo();
    	}
    
    	public interface IWheels
    	{
    		void Foo();
    	}
    
    	public interface IChassie
    	{
    		void Foo();
    	}
    
    
    	public interface IPaintShop
    	{
    		void PaintWheels(IWheels wheels);
    		void PaintChassie(IChassie chassie);
    		void ChromeEngine(IEngine engine);
    	}
    
    	internal class Program
    	{
    		public static void Main(string[] args)
    		{
    			var ps = new
    			{
    				PaintWheels = ReturnVoid.Arguments<IWheels>(wheels => wheels.Foo()),
    				PaintChassie = ReturnVoid.Arguments<IChassie>(chassie => chassie.Foo()),
    				ChromeEngine = ReturnVoid.Arguments<IEngine>(engine => engine.Foo())
    			};
    			var paintShop = ps.ActLike<IPaintShop>();
    
    			var fullCar = new
    			{
    				Foo = ReturnVoid.Arguments(() => Console.WriteLine("Hello World!"))
    			};
    			var car = fullCar.ActLike<IEngine>(typeof(IChassie),typeof(IWheels));
    
    
    			paintShop.PaintWheels((IWheels)car);//need to tell the compiler to cast your car to type IWheels because var car is of type IEngine
    			paintShop.PaintChassie(car as IChassie);//need to tell the compiler to cast your car to type IChassie because var car is of type IEngine
    			paintShop.ChromeEngine(car);
    
    			Console.ReadLine();
    		}
    	}
    }
