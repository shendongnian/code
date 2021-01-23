    public interface IMakeANoise
    {
         void MakeNoise();
    }
    public interface IDog : IMakeANoise
    {
         void Bark();
         int NumberOfDogLegs { get; }
         int NumberOfDogFriends { get; set; }
    }
    
    public interface IDoorBell : IMakeANoise
    {
         void Chime();
    }
