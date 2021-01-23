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
    
    	public interface ICar : IChassie, IWheels, IEngine
    	{
    		
    	}
    
    	public interface IPaintShop
    	{
    		void PaintWheels(IWheels wheels);
    		void PaintChassie(IChassie chassie);
    		void ChromeEngine(IEngine engine);
    		void PaintCar(ICar car);
    	}
    
    	internal class Program
    	{
    		public static void Main(string[] args)
    		{
    			var ps = new
    			{
    				PaintWheels = ReturnVoid.Arguments<IWheels>(wheels => wheels.Foo()),
    				PaintChassie = ReturnVoid.Arguments<IChassie>(chassie => chassie.Foo()),
    				ChromeEngine = ReturnVoid.Arguments<IEngine>(engine => engine.Foo()),
    				PaintCar = ReturnVoid.Arguments<ICar>(car1 => ((IEngine)car1).Foo())
    			};
    			var paintShop = ps.ActLike<IPaintShop>();
    
    			var fullCar = new
    			{
    				Foo = ReturnVoid.Arguments(() => Console.WriteLine("Hello World!"))
    			};
    			var car = fullCar.ActLike<ICar>();
    			var wheel = car.ActLike<IWheels>();
    
    			paintShop.PaintWheels(wheel);//Writes "Hello World!" to console
    			paintShop.PaintChassie(car);//Writes "Hello World!" to console
    			paintShop.PaintCar(car);//Writes "Hello World!" to console
    
    			Console.ReadLine();
    		}
    	}
    }
