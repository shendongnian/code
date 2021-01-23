            typeManager.AddMatch(a, b);
            Console.WriteLine(typeManager.CanMatch(a, b)); // True
            typeManager.DeleteMatch(b, a);
            Console.WriteLine(typeManager.CanMatch(b, a)); // False
            Console.WriteLine(typeManager.CanMatch(a, c)); // False
            typeManager.AddMatch(a, c);
            Console.WriteLine(typeManager.CanMatch(a, c)); // True
            Console.WriteLine(typeManager.CanMatch(a, d)); // False
            typeManager.AddMatch(b, d);
            Console.WriteLine(typeManager.CanMatch(a, d)); // False
            Console.WriteLine(typeManager.CanMatch(d, b)); // True
            typeManager.DeleteMatch(d, b);
            Console.WriteLine(typeManager.CanMatch(d, b)); // False
            Console.WriteLine(typeManager.CanMatch(b, d)); // False
