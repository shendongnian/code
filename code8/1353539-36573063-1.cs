	new JsonResult
	{
		Data = result.Data.Where(x => x.Bidding != null).Select(
			x => 
			{
				var bidRange = this.adgroupRepository.GetBidRange(
					this.contextProvider.CurrentAccount.CurrencyCode, 
					x.PricingModel, 
					x.Bidding.Type);
				return new
				{
					x.ID,
					x.Name,
					BidRange = new
					{
						FloorValue = x.Bidding.FloorPrice ?? bidRange.FloorValue,
						CeilingValue = x.Bidding.CeilingPrice ?? bidRange.CeilingValue
					},
					DefaultBid = x.Bidding.BroadBid
				};
			})
	};
