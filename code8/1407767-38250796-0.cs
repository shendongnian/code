    class Program
    {
        static void Main(string[] args)
        {
            var foodOrders = new List<FoodOrder>
            {
                new FoodOrder { FoodName = "hotdog", OrderDate = new DateTime(2016, 7, 7) },
                new FoodOrder { FoodName = "hamburger", OrderDate = new DateTime(2016, 7, 6) },
                new FoodOrder { FoodName = "taco", OrderDate = new DateTime(2016, 7, 5) },
            };
            var mostRecentFoodOrder = foodOrders.OrderByDescending(f => f.OrderDate).First().FoodName;
            Console.WriteLine(mostRecentFoodOrder);
            //cmd
            //hotdog
            //Press any key to continue . . .
        }
    }
    class FoodOrder
    {
        public string FoodName { get; set; }
        public DateTime OrderDate { get; set; }
    }
