    static void Main(string[] args)
        {
            List<Foo> foos = new List<Foo>();
            foos.Add(new Foo(2));
            List<Foo> newFoo = CreateNewFoo(foos);
            Console.WriteLine(newFoo.First().Bar);
            foos.First().Bar = 5;
            // Since we changed the first object of the old list, and it is the same object in the new list, we will get the new result.
            Console.WriteLine(newFoo.First().Bar);
            Console.Read();
        }
        static List<Foo> CreateNewFoo(List<Foo> foos)
        {
            List<Foo> newFoos = new List<Foo>();
            foreach(Foo foo in foos)
            {
                newFoos.Add(foo);
            }
            return newFoos;
        }
