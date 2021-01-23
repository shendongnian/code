        static void Main(string[] args)
        {
            var trailer = new List<Compartment>
            {
                new Compartment(1, 1, 0),
                new Compartment(2, 1, 0),
                new Compartment(3, 1, 2),
                new Compartment(4, 1, 2),
                new Compartment(5, 1, 2),
                new Compartment(6, 1, 2),
                new Compartment(7, 1, 2),
                new Compartment(8, 1, 2),
            };
            foreach (var compartment in trailer)
            {
                Console.WriteLine(compartment.ToString());
            }
            Console.WriteLine("Press c for canoe or k for kayak");
           
            var keepGoing = true;
            while (keepGoing)
            {
                var input = Console.Read();
                if (input == 99 || input == 107) //99 c, 107 k
                {
                    if (trailer.All(c => c.IsFull()))
                    {
                        keepGoing = false;
                    }
                    else
                    {
                        if (input == 99)
                        {
                            if(!trailer.Any(t=>t.CanAddCanoe()))
                            {
                                Console.WriteLine("Cannot add a canoe!!!!");
                            }
                            else
                            {
                                var firstAvailable = trailer.First(c => c.CanAddCanoe());
                                firstAvailable.AddCanoe();
                            }
                        }
                        else if (input == 107)
                        {
                            if (!trailer.Any(t => t.CanAddKayak()))
                            {
                                Console.WriteLine("Cannot add a kayak!!!!");
                            }
                            else
                            {
                                var firstAvailable = trailer.First(c => c.CanAddKayak());
                                firstAvailable.AddKayak();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Press c for canoe or k for kayak");
                        }
                    }
                    foreach (var compartment in trailer)
                    {
                        Console.WriteLine(compartment.ToString());
                    }
                }
            }
            Console.ReadKey();
        }
    }`
