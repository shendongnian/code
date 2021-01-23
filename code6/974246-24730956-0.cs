    class Item
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static int QuarterFromMonth(int month)
        {
            return (month-1) / 3 + 1;
        }
        static void Main(string[] args)
        {
            Item[] items = 
            { 
                new Item {Id = 1, CreatedDate = new DateTime(2014, 4, 1), Name = "AprilItem"},
                new Item {Id = 1, CreatedDate = new DateTime(2014, 7, 1), Name = "JulyItem"},
                new Item {Id = 1, CreatedDate = new DateTime(2014, 10, 1), Name = "OctoberItem"},
            };
            var itemsByQuarter = items.GroupBy(i => QuarterFromMonth(i.CreatedDate.Month));
            var secondQuarterItemNames = items.Where(i => QuarterFromMonth(i.CreatedDate.Month) == 2).Select(i => i.Name);
        }
    }
