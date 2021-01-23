     public double GetPrice(IEnumerable<CakeDetail> CakeD, int? size)
        {
            if (size.HasValue)
            {
                var Check = CakeD.Where(d => d.SizeID == size.Value).FirstOrDefault();
                if (Check != null)
                {
                    return Check.Price;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                var Check = CakeD.FirstOrDefault();
                if (Check != null)
                {
                    return Check.Price;
                }
                else
                {
                    return 0;
                }
            }
        }
