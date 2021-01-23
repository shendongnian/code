    public class Animal
    {
      public virtual void MakeSound()
      {
        Console.WriteLine("Animal sound");
      }
    }
    public class Dog : Animal
    {
      public override void MakeSound()
      {
        Console.WriteLine("Woof!");
      }
    }
    public class Cat : Animal
    {
      public override void MakeSound()
      {
        Console.WriteLine("Purrrrrrrrrrrrrr");
      }
    }
    class Program
    {
      static void Main(string[] args)
      {
         Animal an = GetAnimal(DateTime.Now);
         an.MakeSound();           
         Console.ReadLine();
      }
      private Animal GetAnimal(DateTime dateTime)
      {
        if (dateTime.DayOfWeek == DayOfWeek.Monday)
        {
          return new Dog();
        }
        else
        {
          return new Cat();
        }
      }
    }
