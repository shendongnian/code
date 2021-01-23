    interface ICanTalk
    {
      void Talk();
    }
    class Animal : ICanTalk
    {
      public void Talk()
      {
        Console.WriteLine("I am animal");
      }
    }
    class Dog : Animal, ICanTalk // note: re-implements
    {
      public new void Talk() // note: method hiding "new" is always evil
      {
        Console.WriteLine("Wroof!");
      }
    }
    static class Test
    {
      internal static void Run()
      {
        object x = new Dog();
        ((Animal)x).Talk();   // I am animal
        ((Dog)x).Talk();      // Wroof!
        ((ICanTalk)x).Talk(); // Wroof!
      }
    }
