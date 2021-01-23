     private static double GenericCostCalculation(double units)
        {
            var rates = new List<Cost>
            {
                new Cost { SlabFrom = 0, SlabTo = 100, RatePerUnit = 10 },
                new Cost { SlabFrom = 101, SlabTo = 500, RatePerUnit = 20 },
                
                new Cost { SlabFrom = 501, SlabTo = 1000,RatePerUnit = 30 },
                
                new Cost { SlabFrom = 1001, SlabTo = 2000, RatePerUnit = 40 }
            };
            double cost = 0;
            foreach (var rate in rates)
            {
                if (units > 0)
                {
                    if ((rate.SlabTo == rates.Max(x => x.SlabTo)) || (units < rate.SlabTo))
                    {
                        cost += units * rate.RatePerUnit;
                        units = 0;
                    }
                    else
                    {
                        cost += (rate.SlabTo - rate.SlabFrom) * rate.RatePerUnit;
                        units -= (rate.SlabTo - rate.SlabFrom);
                    }
                }
            }
            return cost;
        }
