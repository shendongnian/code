    Console.WriteLine("Enter five letter of the alphabet");
            char[] sortAlpha = new char[5];
            char temp;
            //Getting the values from the user.
            for (int i = 0; i < sortAlpha.Length; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                sortAlpha[i] = input[0];
            }
            //bubble sort.
            for (int write = 0; write < sortAlpha.Length; write++)
            {
                for (int sort = 0; sort < sortAlpha.Length - 1; sort++)
                {
                    //comparing the unicode values of the chars.
                    if ((int)sortAlpha[sort] > (int)sortAlpha[sort + 1])
                    {
                        temp = sortAlpha[sort + 1];
                        sortAlpha[sort + 1] = sortAlpha[sort];
                        sortAlpha[sort] = temp;
                    }
                }
            }
            for (int i = 0; i < sortAlpha.Length; i++)
            {
                Console.WriteLine(sortAlpha[i]);
            }
            Console.ReadKey();
        }
