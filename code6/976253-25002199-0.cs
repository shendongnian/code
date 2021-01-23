        static char[] numbers = {'0','1','2','3','4','5','6','7','8','9'};
        static bool continuar = true;
        private static void Start(int maxLength)
        {
            for (int i = 0; i <= maxLength; i++)
                Permutations(i, 0, "");
        }
        private static void Permutations(int keyLength, int position, string baseString)
        {
            bool print = true;
            if (continuar)
            {
                for (int i = 0; i < numbers .Length; i++)
                {
                    string temp = baseString + numbers [i];
                    if (position <= keyLength - 1)
                    {
                        Permutations(keyLength, position + 1, temp);
                        print = false;
                    }
                    if (continuar && print)
                        Console.WriteLine(temp);
                }
            }
        }
