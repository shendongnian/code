    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Grizzlies live in water = " + Pets.NorthAmericanGrizzly.LivesInWater());
            Console.WriteLine("Fish live in water = " + Pets.Fish.LivesInWater());
            Console.WriteLine("Cat is a pet enum = " + Pets.Cat.IsPetEnum());
            Console.WriteLine("Date Time Kind of UTC is a pet enum = " + DateTimeKind.Utc.IsPetEnum());
            Console.ReadLine();
        }
    }
    public enum Pets
    {
        Dog,
        Cat,
        Fish,
        Shark,
        NorthAmericanGrizzly
    }
    public static class PetExtensions
    {
        public static bool LivesInWater(this Pets pet)
        {
            return pet == Pets.Fish || pet == Pets.Shark;
        }
    }
    public static class EnumExtensions
    {
        public static bool IsPetEnum(this Enum @enum)
        {
            return @enum is Pets;
        }
    }
