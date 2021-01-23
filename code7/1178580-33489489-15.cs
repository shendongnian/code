    // type-level natural numbers
    class Z {}
    class S<N> {}
    
    // Vec defined as in Agda; cases turn into subclasses
    abstract class Vec<N, T> {}
    class Nil<T> : Vec<Z, T> {}
    // simulate type indices by varying
    // the parameter of the base type
    class Cons<N, T> : Vec<S<N>, T>
    {
        public T Head { get; private set; }
        public Vec<N, T> Tail { get; private set; }
        public Cons(T head, Vec<N, T> tail)
        {
            this.Head = head;
            this.Tail = tail;
        }
    }
    
    // put First in an extension method
    // which only works on vectors longer than 1
    static class VecMethods
    {
        public static T First<N, T>(this Vec<S<N>, T> vec)
        {
            return ((Cons<N, T>)vec).Head;
        }
    }
    public class Program
    {
        public static void Main()
        {
            var vec1 = new Cons<Z, int>(4, new Nil<int>());
            Console.WriteLine(vec1.First());  // 4
            var vec0 = new Nil<int>();
            Console.WriteLine(vec0.First());  // type error!
        }
    }
