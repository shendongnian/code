     public static void Main(string[] args)
        {
            var file = string.Format("{0}//foobar.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            var factory = new PromotionFactory();
            var promotions = factory.Parse(file);
            promotions.ToList().ForEach(Console.WriteLine);
            Console.ReadKey();
        }
