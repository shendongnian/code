        static void Main(string[] args)
        {
            Serie s = new Serie();
            s.Add(1).Add(2);
            for (int i = 0; i < s.Count(); i++)
            {
                Console.WriteLine(s[i]);
            }
            Console.ReadLine();
        }
