    unsafe class Program {
    
        static void foo(bool* b) {
            *b = true;
        }
    
        static void Main(string[] args) {
            bool x = false;
            Console.WriteLine(x); // Prints false
            foo(&x);
            Console.WriteLine(x); // Prints true
        }
    
    }
