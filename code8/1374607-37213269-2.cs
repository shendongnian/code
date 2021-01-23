    public class LetsHearWhatItHasToSay : IAnimalVisitor {
        public void Visit(Dog dog) {
            if (dog.IsBarking) dog.Speak();
            else Console.WriteLine("Good boy!");
        }
        public void Visit(Cat cat) {
            if (cat.IsMewling) cat.Speak();
            else Console.WriteLine("Pretty kitty");
        }
    }
