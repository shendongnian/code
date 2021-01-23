    class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = 24;
            var secondNumber = 4;
            var op = "+";
            var result = new List<List<string>>();
            for (int i = 0; i <= firstNumber; i++)
            {
                var list = new List<string>();
                for (int j = 0; j < secondNumber; j++)
                {
                    list.Add(i.ToString());
                    list.Add(op);
                    list.Add(j.ToString());
                    list.Add("=");
                    list.Add((i + j).ToString());                   
                }
                result.Add(list);
            }
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }
            Console.ReadLine();
        }
    }
