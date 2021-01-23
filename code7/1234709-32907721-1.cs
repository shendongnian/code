    class Program
    {
        static void Main(string[] args)
        {
            Console.CancelKeyPress += (o, e) =>
                {//prevent from stopping after Ctrl+C
                    e.Cancel = true;
                };
            Console.WriteLine("\n Enter a matrix. Press Ctrl+C when you will have ended.");
            string text = Console.In.ReadToEnd();
            Console.WriteLine("\nParsing...\n");
            int[,] res2a;
            try
            {              
                res2a = parse(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ",\n " + ex.StackTrace);
                return;
            }
            Console.WriteLine("\nYou enter: \n");
            for (int i = 0; i < res2a.GetLength(1); i++)
            {
                for (int j = 0; j < res2a.GetLength(0); j++)
                    Console.Write("0x{0:X} ", res2a[j, i]);
                Console.WriteLine();
            }
         
        }
        static int[,] parse(string text)
        { 
            int max_len = 0;
            List<List<int>> res2x = new List<List<int>>();
            string [] tmp1 = text.Split(new char []{'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            foreach(string s1 in tmp1)
            {
                string [] tmp2 = s1.Split(new char [] {' '}, StringSplitOptions.RemoveEmptyEntries);
                res2x.Add(new List<int>(tmp2.ToList().ConvertAll<int>((s)=>int.Parse(s.Trim()))));
                if (tmp2.Length > max_len)
                    max_len = tmp2.Length;
            }
            int[,] res2a = new int[max_len, tmp1.Length];
            for (int j = 0; j < tmp1.Length; j++ )
                for (int i = 0; i < res2x[j].Count; i++)                
                    res2a[i, j] = res2x[j][i];
            return res2a;
        }
    }
