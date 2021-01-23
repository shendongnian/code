    public interface IAnimal
    {
        void ShowVoice();
    }
    public class Cat : IAnimal
    {
        public void WiggleTail()
        {
            Console.Write("Wiggling tail...")
        }
    
        public void ShowVoice()
        {
            Console.Write("meow");
        }
    }
    
    public class Dog : IAnimal
    {
        public void GivePaw()
        {
            Console.Write("Giving paw...")
        }
        public void ShowVoice()
        {
            Console.Write("woof");
        }
    }
    public static void main(){
        IAnimal cat = new Cat();
        IAnimal dog = nes Dog();
        cat.ShowVoice();
        //cat.WiggleTail(); - cannot do that on interface
        dog.ShowVoice();
        //dog.GivePaw(); - cannot do that on interface
        Cat catInst = new Cat();  
        Dog dogInst = new Dog(); 
        catInst.WiggleTail(); // you can do that because it is not an interface that we make call to
        dogInst.GivePaw(); //the same as with cat
        // catInst.GivePaw(); - cannot do this because it does not exist in the class
    }
