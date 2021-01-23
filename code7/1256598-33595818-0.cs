    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Foo[] FooCar = new Foo[6];
            string[] _NamesForFoo = { "Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf" };
            int FoosToMake = rnd.Next(1, _NamesForFoo.Length);
            Console.WriteLine("Making {0} FooCars.", FoosToMake);
            //create the cars
                for (int i = 0; i < FoosToMake; i++)               
                {                
                    FooCar[i] = new Foo( _NamesForFoo[i], rnd.Next(100,500));
                }
            //list the cars
                for (int i = 0; i < FoosToMake; i++)
                {
                    Console.WriteLine("FooCar {0} has a count of {1}", FooCar[i]._FooName, FooCar[i]._FooCount );
                }
            //modify a car
                FooCar[0]._FooCount += 2500;
            //show change to specific car
                Console.WriteLine("FooCar {0} now has a count of {1}", FooCar[0]._FooName, FooCar[0]._FooCount);
            Console.ReadKey();
        }
        public class Foo
        {
            public string _FooName { get; set; }
            public int _FooCount { get; set; }
            public Foo(string _NameIn, int _CountIn)
            {
                _FooName = _NameIn;
                _FooCount = _CountIn;
            }
        }
    }
