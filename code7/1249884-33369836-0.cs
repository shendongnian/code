    // notice the recursive definition, we require the generic parameter
    // to be a generic parameter of itself - allowing AbstractBaseClass
    // to not be aware of its subclasses like in the other answers.
    public abstract class AbstractBaseClass<T> where T : AbstractBaseClass<T>
    {
        public abstract void Create(T param1);
    }
    public class Concrete : AbstractBaseClass<Concrete>
    {
        public override void Create(Concrete param1)
        {
            Console.WriteLine("Hello!");
        }
    }
