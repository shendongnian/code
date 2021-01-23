    public abstract class Animal
    {
        public int ID { get; set; }
        public int NumberOfLegs { get; set; }
    }
    public class Dog : Animal
    {
        public string OtherDogRelatedStuff { get; set; }
    }
    public class Bird : Animal
    {
        public string OtherBirdRelatedStuff { get; set; }
    }
