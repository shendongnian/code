    List<RateRecord> ls = occupancyList.Where(s => s.publish_flag.Contains("0020")).Select(x => new RateRecord()
            {
                RATECODE = x.rate_code.Trim(),
                Occ = new List<RateRecordDtl>() 
                { 
                    new RateRecordDtl { date = dateFromShort, pricing = new List<Pricing>() {
                        new Pricing {adults = 2, price = x.rate },
                        new Pricing {adults = 1, price = x.rate }} 
                }
            }
            ).ToList();
