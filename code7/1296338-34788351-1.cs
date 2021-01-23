    public static Nullable<decimal> GetOsmiSubtractions(List<OSMI> dgselecteditems)
        ///Get efffect of selected items subtracking to OSMI
        {
            Nullable<decimal> sum = 0;
            String Test = "Y";
             
            
            foreach (OSMI p in dgselecteditems)
            {
                String OverRide = new string(p.OsmiOverride.Take(1).ToArray());
                
                if ((string.Compare(OverRide, Test, true) == 0))
                {
                    sum += p.InvValue;
                }
            }
            return decimal.Round((decimal)sum, 2);
        }
