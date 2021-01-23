        static void Foo3()
        {
            string[] sequence1 = new[] { "12", "34", "567" };
            string[] sequence2 = new[] { "ab", "cd", "efg" };
            var joinResult = sequence1.GroupJoin(
                sequence2,
                element1 => GetKey1(element1),  //Just to see that a lambda is just another way to specify a delegate
                element2 => GetKey2(element2),  //Just to see that a lambda is just another way to specify a delegate
                (n1, gn2) =>
                {
                    // place a breakpoint on the next line
                    return new {n1, gn2};
                });
            Console.WriteLine("joinResult: ");
            joinResult.ToList().ForEach(Console.WriteLine);
            var result = joinResult.SelectMany(
                x =>
                {
                    // place a breakpoint on the next line
                    return x.gn2;
                },
                (x, n2) =>
                {
                    // place a breakpoint on the next line
                    return new {x.n1, n2};
                });
            Console.WriteLine("result: ");
            result.ToList().ForEach(Console.WriteLine);
        }
        private static int GetKey1(string element1)
        {
            // place a breakpoint on the next line
            return element1.Length;
        }
        private static int GetKey2(string element2)
        {
            // place a breakpoint on the next line
            return element2.Length;
        }
