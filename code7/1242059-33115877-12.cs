    public interface IDog
    {
         void Bark();
         int NumberOfDogLegs { get; }
         int NumberOfDogFriends { get; set; }
    }
    
    public interface IDoorBell
    {
         void Chime();
    }
