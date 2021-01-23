    class Animal         { public virtual  void Speak() { Console.WriteLine("Most animals make some sort of noise.") ; } }
    class Dog : Animal   { public virtual  void Speak() { Console.WriteLine("Dog: Woof!") ; } }
    class Cat : Animal   { public new      void Speak() { Console.WriteLine("Meow!") ; } }
    class Sheep : Animal { public override void Speak() { Console.WriteLine("Baaa!") ; } }
    static void Main( string[] args )
    {
      Animal[] menagerie = { new Animal() , new Dog() , new Cat() , new Sheep() , } ;
      
      foreach ( Animal creature in menagerie )
      {
        Console.Write( "{0}:\t" , creature.GetType().Name ) ;
        creature.Speak() ;
      }
      
      return;
    }
