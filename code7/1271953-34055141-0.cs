    class Company
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    static void Main()
    {
        //setup
        var list = new List<Company>();
        list.Add(new Company
        {
            Description = "Test",
            Id = 35,
            IsDeleted = false
        });
        list.Add(new Company
        {
            Description = "Test",
            Id = 52,
            IsDeleted = false
        });
        list.Add(new Company
        {
            Description = "Test",
            Id = 75,
            IsDeleted = true
        });
        /* code you are looking for */
        var providers = from c in list
                        where !c.IsDeleted
                        select new { c.Description, Id = "C" + c.Id };
        foreach (var provider in providers)
        {
            Console.WriteLine(provider.Id);
        }
            Console.ReadKey();
    }
