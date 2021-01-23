    class Program
    {
        static void Main(string[] args)
        {
            ManagerViewModel viewModel = new ManagerViewModel
            {
                workType = "Garden"
            };
            // By implicit conversion
            Manager manager1 = viewModel;
            manager1.SayHi();
            // By extension method
            ShopManager manager2 = viewModel.ToEntity<ShopManager>();
            manager2.SayHi();
            Console.ReadLine();
        }
    }
