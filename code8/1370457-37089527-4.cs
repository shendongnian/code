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
    			
			    //each of these 3 calls prints "Hello World!" to the console
		    	paintShop.PaintWheels((IWheels)car);//need to tell the compiler to cast your car to type IWheels because var car is of type IEngine
	    		paintShop.PaintChassie(car as IChassie);//need to tell the compiler to cast your car to type IChassie because var car is of type IEngine
		    	paintShop.ChromeEngine(car);//works sans cast because var car is of type IEngine
    
			    //each of these 3 calls prints "Hello World!" to the console, too
    			dynamic dynamicCar = car;
	    		paintShop.PaintWheels(dynamicCar);//by using dynamic you disable the compile time
		    	paintShop.PaintChassie(dynamicCar);//type checking and the compiler "trusts you" on the typing
			    paintShop.ChromeEngine(dynamicCar);//since Impromptu wrapped your object and implemented the interfaces for you, there is no runtime exception
                
                Console.ReadLine();
    		}
    	}
    }
