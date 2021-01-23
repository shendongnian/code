    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<OrderObject> db = new List<OrderObject> 
            { 
                new OrderObject { Count=1, CreateDate=DateTime.Now.Subtract(TimeSpan.FromDays(0)), IsValid=true },
                new OrderObject { Count=2, CreateDate=DateTime.Now.Subtract(TimeSpan.FromDays(1)), IsValid=false },
                new OrderObject { Count=3, CreateDate=DateTime.Now.Subtract(TimeSpan.FromDays(2)), IsValid=false },
                new OrderObject { Count=4, CreateDate=DateTime.Now.Subtract(TimeSpan.FromDays(3)), IsValid=true },
                new OrderObject { Count=5, CreateDate=DateTime.Now.Subtract(TimeSpan.FromDays(4)), IsValid=false },
            };
            var validItemsOrderedByCount = (from obj in db
                                            where obj.IsValid
                                            orderby obj.Count
                                            select obj);
            var nonValidItemsOrderedByDateCreated = (from obj in db
                                                     where obj.IsValid == false
                                                     orderby obj.CreateDate
                                                     select obj);
            var combinedList = validItemsOrderedByCount
                .Concat(nonValidItemsOrderedByDateCreated)
                .ToList();
        }
    }
    class OrderObject
    {
        public bool IsValid { get; set; }
        public DateTime CreateDate { get; set; }
        public int Count { get; set; }
    }
