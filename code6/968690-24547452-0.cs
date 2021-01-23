    public class Animal
    {
       public void MakeSound(SoundStrategy soundStrategy)
       {
           soundStrategy.MakeSound();
       }
    }
    public class Bark : SoundStrategy
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof");
        }
    }
    public class Meow : SoundStrategy
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }
    }
    public class BarkLoudly : Bark
    {
        public override void MakeSound()
        {
            Console.WriteLine("WOOF");
        }
    }
