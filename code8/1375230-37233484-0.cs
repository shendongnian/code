    static int IndexOf<T>(T[,] array, T toFind)
        {
            int i = -1;
            foreach (T item in array)
            {
                ++i;
                if (toFind.Equals(item))
                    break ;
            }
            return i;
        }
        static string GetRandomString(string[,] array, string toFind)
        {
            int lineLengh = array.Length / array.Rank;
            int index = IndexOf(array, toFind);
            Random random = new Random((int)DateTime.Now.Ticks);
            index = random.Next(index + 1, (index / lineLengh + 1) * lineLengh);
            return array[index / lineLengh, index % lineLengh];
        }
        static void Main(string[] args)
        {
            string[,] array = new string[,]
            {
                {"cat", "dog", "plane"},
                {"bird", "fish", "elephant"},
            };
            Console.WriteLine(GetRandomString(array, "bird"));
            Console.ReadKey();
        }
