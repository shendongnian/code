        static void Main(string[] args)
        {
            Console.WriteLine("./foo".Simplify());         // => foo
            Console.WriteLine("foo/./bar".Simplify());     // => foo/bar
            Console.WriteLine("foo/../bar".Simplify());    // => bar
            Console.WriteLine("foo/bar/../..".Simplify()); // => .
            Console.WriteLine("/foo/bar/../..".Simplify()); // => /
            Console.WriteLine("../bar".Simplify());        // => ../bar
            Console.WriteLine("..".Simplify());            // => ..
            Console.WriteLine(".".Simplify());             // => .
            Console.WriteLine("/foo".Simplify());          // => /foo
            Console.WriteLine("/".Simplify());             // => /
            Console.ReadKey();
        }
