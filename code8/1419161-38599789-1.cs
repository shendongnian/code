    class Animal
    {
      
      public double Height{get;set;}
      public string Name {get; private set;}
      public Animal()
      {
        this.height=0;
      }
      protected Animal(string name)
      {
        Name=name;
      }
    }
    
    class Dog : Animal
    {
       public string FavoriteFood{get;set;}
    
      //this calls the constructor with name parameter
      public Dog(string name):base(name)
      {
        this.FavoriteFood="No favorite food";
      }
      
      //this one calls the parameterless constructor
      protected Dog(int height):base()
      {
        this.favFood="No favorite food";
      }
    }
