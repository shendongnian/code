        I do agree with Stanley. Just because you can create an abstract class doesn't mean you should. Here is the scenario when you do need an abstract class:
        Suppose you are creating a method in static class to handle animal sound and do something, for example
    Public static class AnimalHelper
    {
    Public static string NotifySound(this Animal animal)
    {
    return animal. GetType().Name + " "  + animal.Sound.ToString() + "s";
    }
    }
    Now here you don't know your animal and it's SoundType. So you create an abstract class:
    Public abstract class Animal
    {
    public abstract SoundType Sound{get;}
    }
    public enum SoundType
    {
    Bark,
    Roar,
    Meow
    }    
    public class Dog:Animal
    {
    public override SoundType Sound{get{return SoundType.Bark;}}
    }
    public class Lion:Animal
    {
    public override SoundType Sound{get{return SoundType.Roar;}}
    }
    So here you have created universal method for handling sound using power of OOP. I hope this gives you right perspective to use abstraction.
