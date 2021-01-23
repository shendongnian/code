    private static double CalculateRate(int totalUsage)
    {
        var applicableSlabRates = sr.Where(r => r.SlabFrom <= totalUsage).OrderBy(r => r.SlabFrom);
            double cost = 0;
            foreach (var r in applicableSlabRates)
            {
                int range = 0;
                if ((r.SlabFrom < totalUsage && totalUsage <= r.SlabTo) || r.SlabTo == null)
                {
                    range = totalUsage;
                }
                else
                {
                    range = Convert.ToInt32( r.SlabTo ) - r.SlabFrom;
                }
                cost += range * r.Rate;
                totalUsage = totalUsage - range;
            }
            return cost;
    }
     public class SlabRate
     {
            public int SlabFrom { get; set; }
            public int? SlabTo { get; set; }
            public double Rate { get; set; }
     }
     static List<SlabRate> sr = new List<SlabRate>();
        sr.Add(new SlabRate() { SlabFrom = 0, SlabTo = 100, Rate = 5.00 });
        sr.Add(new SlabRate() { SlabFrom = 101, SlabTo = 500, Rate = 10.00 });
        sr.Add(new SlabRate() { SlabFrom = 501, SlabTo = null, Rate = 15.00 });
