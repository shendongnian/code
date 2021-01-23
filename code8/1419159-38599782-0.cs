    class Animal
    {
        public double Height { get; set;}
        public Animal(double height)
        {
            Height = height;
        }
    }
    class Dog: Animal
    {
        public string FavoriteFood { get; set; }
        public Dog(double height): base(height) 
        {
            FavoriteFood = "No favorite food";
        }
    }
   
