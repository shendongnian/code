            DateTime startDateTime = Convert.ToDateTime(start);
            DateTime endDateTime = Convert.ToDateTime(end);
            int fetched = 0;
            int totalFetched = 0;
            
            do
            {
                //fetch a batch of 1000 records
                var _prices = _db.TickerData.Where(p => p.Time >= startDateTime && p.Time <= endDateTime)
                                        .OrderBy(p => p.Time)
                                        .Skip(totalFetched)
                                        .Take(1000)
                                        .ToList();                
                //do here whatever you want with your batch of 1000 records
                fetched = _prices.Count;
                totalFetched += fetched;
            }
            while (fetched > 0);
