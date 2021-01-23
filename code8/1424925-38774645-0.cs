    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Projects\StackOverRegX\StackOverRegX\input.txt";
            string[] x = new string[100];
            int index = 0;
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if(s.Contains("initTest"))
                        {
                            x[index] = sr.ReadLine() + " \n " + sr.ReadLine();
                            index++;
                        }
                    }
                }
            }
            for (int i = 0; i < 100; i++)
            {
                if(x[i]!=null)
                Console.WriteLine(x[i]);
            }
            Console.ReadKey();
        }
    }
