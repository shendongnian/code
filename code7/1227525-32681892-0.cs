            DateTime startDateTime = Convert.ToDateTime(start);
            DateTime endDateTime = Convert.ToDateTime(end);
            
            do
            {
                //fetch a batch of 1000 records
                var _prices = _db.TickerData.Where(p => p.Time >= startDateTime && p.Time <= endDateTime)
                                        .OrderBy(p => p.Time)
                                        .Take(1000)
                                        .ToList();                
                //do here whatever you want with your batch of 1000 records
            }
            while (_prices.Count > 0);
