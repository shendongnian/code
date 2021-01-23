        public static void Main()
        {
            double result = 1.0f / new ProvideThree().Three;
            double resultVirtual = 1.0f / new ProvideVirtualThree().Three;
            double resultConstant = 1.0f / 3;
            short parsedThree = short.Parse("3");
            double resultParsed = 1.0f / parsedThree;
            Console.WriteLine("Result of 1.0f / ProvideThree = {0}", result);
            Console.WriteLine("Result of 1.0f / ProvideVirtualThree = {0}", resultVirtual);
            Console.WriteLine("Result of 1.0f / 3 = {0}", resultConstant);
            Console.WriteLine("Result of 1.0f / parsedThree = {0}", resultParsed);
            Console.ReadLine();
        }
        public class ProvideThree
        {
            public short Three
            {
                get { return 3; }
            }
        }
        public class ProvideVirtualThree
        {
            public virtual short Three
            {
                get { return 3; }
            }
        }
