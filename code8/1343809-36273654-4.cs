    public static List<Car> myList = new List<Car>();
    static void Main(string[] args)
            {
                myList.Add(new Car() { Model = "A", Name = "XXX", Brand = "Some Brand" });
                myList.Add(new Car() { Model = "B", Name = "YYY", Brand = "Some Brand1" });
                myList.Add(new Car() { Model = "C", Name = "ZZZ", Brand = "Some Brand2" });
                Car search = new Car();
                Console.Write("Search for model:");
                search.Model = Console.ReadLine();
                Console.WriteLine("Following Result Found for {0}", search.Model);
                SearchLog(search);
           }
