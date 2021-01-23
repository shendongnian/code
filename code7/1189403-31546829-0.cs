        public static bool check(string nextvaluebinary)
        {
            bool test = true;
            for (int i = -1; i < 8; ++i)
            {
                i++;
                System.Console.WriteLine(nextvaluebinary[i] + " " + nextvaluebinary[i + 1]);
                if (nextvaluebinary[i] == '1')
                {
                    System.Console.WriteLine("Activated");
                    if (nextvaluebinary[i + 1] == '0')
                    {
                        test = false;
                        System.Console.WriteLine("false");
                    }
                }
                else
                {
                    test = true;
                }
                if (test == false)
                {
                    break;
                }
            }
            return test;
        }
