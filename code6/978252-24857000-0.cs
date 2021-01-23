    namespace C.Fiddle
    {
        class Program
        {
            static void Main(string[] args)
            {
                Tester.Stack<Bear> bears = new Tester.Stack<Bear>();
                Tester.Stack<Animal> animals = bears;
                animals.Push(new Camel());
            }
        }
    
        class Animal { }
        class Bear : Animal { }
        class Camel : Animal { }
    
        public class Tester
        {
            public class Stack<T>
            {
                int position;
                T[] data = new T[10];
                public void Push(T obj) { data[position++] = obj; }
                public T Pop() { return data[position--]; }
            }
    
            public class ZooCleaner
            {
                private static void Wash<T>(Stack<Animal> animals) where T : Animal { }
            }
        }
    }
