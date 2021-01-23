      class Program {
            static void Main(string[] args) {
                try {
                    foreach (var item in GetStrings()) {
                        Console.WriteLine();
                    }
                }
                catch (Exception ex) {
            }
        }
        private static IEnumerable<string> GetStrings() {
            // REPEATEDLY throws this exception
            throw new Exception();
            yield break;
        }
    }
