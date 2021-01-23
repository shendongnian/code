    class City
    {
        public int CarbonId { get; set; }
        public static IOrderedEnumerable<City> OrderByIrregularCarbonId(
             IEnumerable<City> sequence,
             params int[] carbons)
        {
            return sequence.OrderBy(T => Array.IndexOf(carbons, T.CarbonId));
        }
    }
    public static void Main(string[] args)
    {
        int[] carbonOrder = new[] { 3, 6, 2, 7, 9 };
        List<City> cities = City.OrderByIrregularCarbonId(db.GetCities, carbonOrder).ToList();
    }
