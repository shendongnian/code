    namespace RandomBug
    {
        class Program
        {
            static void Main(string[] args)
            {           
                for (int i = 0; i < 1000000; i++)
                    Random.Range(0,100);                       
            }
        }
    }
