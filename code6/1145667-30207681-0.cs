      static void Main(string[] args)
            {
                int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray<int>();
                int max = 0;
                int mostRepeated = arr[0];
                foreach(int element in arr)
                {
                    int[] temp = arr.Where(i => i == element).ToArray();
                    if(temp.Length > max)
                    {
                        max = temp.Length;
                        mostRepeated = element;
                    }
                }
                Console.WriteLine(mostRepeated);
            }
