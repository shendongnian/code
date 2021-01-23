    public abstract class Animal {
        public abstract SoundType Sound{get;}
    }
    
    public enum SoundType{
        Bark,
        Roar,
        Meow
    }    
    public class Dog:Animal {
        public override SoundType Sound { get { return SoundType.Bark; } }
    }
    public class Lion:Animal {
        public override SoundType Sound { get { return SoundType.Roar; } }
    }
