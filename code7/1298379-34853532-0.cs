    //ABSTRACT CLASS:
    public abstract class Car
    {
        public abstract void Manufactured(); //abstract method
    }
    public class Honda : Car
    {
        public override void Manufactured()
        {
            Console.WriteLine("Honda is a Japanese car.");
        }
    }
    public class Renult : Car
    {
        public override void Manufactured()
        {
            Console.WriteLine("Renault is a Franch car.");
        }
    }
      //INTERFACE:
    public interface IBike
    {
        void Manufactured();
    }
    public interface KBike
    {
        void Model();
    }
					
    public class Suzuki : IBike , KBike // multiple inheritance using interface
    {
        public void Manufactured()
        {
            Console.WriteLine("Suzuki is prodused on Japan.");
        }
	   public void Model()
        {
            Console.WriteLine("Suzuki is prodused on Japan.");
        }
    }
