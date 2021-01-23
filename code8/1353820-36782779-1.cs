    namespace ResString
    {
        class Program
        {
            /// <summary>
            /// Description for the first resource.
            /// </summary>
            private static readonly ResourceString firstRes = "First";
            /// <summary>
            /// Description for the second resource.
            /// </summary>
            private static readonly ResourceString secondRes = "Second";
            /// <summary>
            /// Description for the format string.
            /// </summary>
            private static readonly ResourceString format = "{0} {1}";
            static void Main(string[] args)
            {
                ResourceString.Resolver = new French();
                Console.WriteLine(String.Format(format, firstRes, secondRes));
            }
            private class French : IResourceResolver
            {
                public string Resolve(string key, string defaultValue)
                {
                    switch (key)
                    {
                        case "ResString.Program.firstRes":
                            return "Premier";
                        case "ResString.Program.secondRes":
                            return "Deuxième";
                        case "ResString.Program.format":
                            return "{1} {0}";
                    }
                    return defaultValue;
                }
            }
        }
    }
