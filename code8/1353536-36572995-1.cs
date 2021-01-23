     new JsonResult
     {
           Data = result.Data.Where(x => x.Bidding != null).Select(x => 
           {
               var bidRange = adgroupRepository.GetBidRange(
                    contextProvider.CurrentAccount.CurrencyCode, 
                    x.PricingModel, 
                    x.Bidding.Type);
               new
               {
                   ID = x.ID,
                   Name = x.Name,
                   BidRange = new
                   {
                       FloorValue = x.Bidding.FloorPrice ?? bidRange.FloorValue,
                       CeilingValue = x.Bidding.CeilingPrice ?? bidRange .CeilingValue
                   },
                   DefaultBid = x.Bidding.BroadBid
               }
           })
     };
