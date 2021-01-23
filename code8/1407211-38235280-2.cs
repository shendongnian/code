        public static void PrintTree(Dictionary<T, IEnumerable<T>> tree, Getter g) {
            foreach (var value in tree) {
                Console.Write("[" + g(value.Key).ToString() + "]: ");
                foreach (var node in value.Value)
                    Console.Write(g(node).ToString() + " ");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
