    public interface IMakeANoise
    {
         public void MakeNoise();
    }
    public interface IDog : IMakeANoise
    {
         public void Bark();
         public int NumberOfDogLegs { get; }
         public int NumberOfDogFriends { get; set; }
    }
    
    public interface IDoorBell : IMakeANoise
    {
         public void Chime();
    }
