    public class Animal
    {
       // In this case we pass the sound strategy to the method. However you could also
       // get the strategy from a protected abstract method, or you could even use some sort
       // of IOC container.
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
