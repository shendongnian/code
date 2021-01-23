    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] request = new String[2];
                request[0] = "Name";
                request[1] = "Occupaonti";
                string json = JsonConvert.SerializeObject(request);
            }
        }
    }
