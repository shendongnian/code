    class Program
    {
        static void Main(string[] args)
        {
            FuncMapper funcMapper = new FuncMapper();
            funcMapper.Register(new Func<string, string>(DoString));
            funcMapper.Register(new Func<int, int>(DoInt));
            Console.WriteLine("Value: {0}", funcMapper.Execute<string, string>("Test"));
            Console.WriteLine("Value: {0}", funcMapper.Execute<int, int>(10));
            Console.Read();
        }
        static string DoString(string param)
        {
            return param;
        }
        static int DoInt(int param)
        {
            return param;
        }
    }
