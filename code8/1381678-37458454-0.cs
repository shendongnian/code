    // Note: Target method is required to have an empty parameter list
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class PetAbilityAttribute : Attribute
    {
    }
    public class MyPets
    {
        public MyPets()
        {
            Pets = new List<Pet>();
        }
        public ICollection<Pet> Pets { get; set; }
        // Discover PetAbilityAttribute methods on the concrete pet type and invoke them dynamically
        public void IteratePetAbilities()
        {
            foreach (var pet in Pets)
            {
                Console.WriteLine("Pet '" + pet.PetName + "' enters the stage");
                var abilities = pet.GetType().GetMethods().Where(x => x.GetCustomAttributes(typeof(PetAbilityAttribute), true).Any());
                foreach (var abilityMethod in abilities)
                {
                    Console.Write("# {0,12}() # ", abilityMethod.Name);
                    abilityMethod.Invoke(pet, new object[] { });
                }
                Console.WriteLine();
            }
        }
    }
    public abstract class Pet
    {
        public string PetName { get; set; }
        [PetAbility]
        public abstract void MakeNoise();
        // Note: this is not marked as an ability here
        public abstract void GoSleep();
    }
    public class Dog : Pet
    {
        [PetAbility] // no effect, since base already has this attribute
        public override void MakeNoise()
        {
            Console.WriteLine("Says woof");
        }
        // not marked as an ability
        public override void GoSleep()
        {
            Console.WriteLine("Goes to the dogs house and sleeps");
        }
    }
    public class Terrier : Dog
    {
        [PetAbility]
        public void HuntACat()
        {
            Console.WriteLine("Starts running after a poor little cat");
        }
        [PetAbility] // Unlike a regular dog, the Terrier goes to sleep by ability :)
        public override void GoSleep()
        {
            base.GoSleep();
        }
    }
    public class Cat : Pet
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Says meow");
        }
        [PetAbility]
        public void ClimbTree()
        {
            Console.WriteLine("Climbs a tree and is to scared to return on its own");
        }
        [PetAbility] // makes GoSleep an ability only for cats, even though the method exists in base class
        public override void GoSleep()
        {
            Console.WriteLine("Refuses to sleep and starts sharpening its claws");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myPets = new MyPets();
            myPets.Pets.Add(new Cat() { PetName = "Super Cat" });
            myPets.Pets.Add(new Dog() { PetName = "Little Dog" });
            myPets.Pets.Add(new Terrier() { PetName = "Hunter" });
            myPets.IteratePetAbilities();
        }
    }
