     class genericClass<T,U>
     {
        public T a ;
        public U e;
     }
        static void Main(string[] args)
        {
            genericClass<string, int> gen1 = new genericClass<string, int>();
            genericClass<string, int> gen2 = new genericClass<string, int>();
            genericClass<string, int> source = new genericClass<string, int>();
            source.a = "test1";
            source.e = 1;
            
            Copy<string,int>(gen1, source);
            Copy<string, int>(gen2, source);
            Console.WriteLine(gen1.a + " " + gen1.e);
            Console.WriteLine(gen2.a + " " + gen2.e);
            Console.ReadLine();
        }
        static void Copy<T, U>(genericClass<T, U> dest, genericClass<T, U> source)
        {
            dest.a = source.a;
            dest.e = source.e;
        }
