	public QuoteResult GetTruckInformation(QuoteData data)
	{
		QuoteResult qr = null;
		using (TruckDb db = new TruckDb())
		{
			var tareTotal = db.ChassisModel.Where(x => x.Id == data.ChassisId).FirstOrDefault();
			if (tareTotal != null)
			{
				var item = db.TruckItems.Where(x => x.Model == tareTotal.Name).FirstOrDefault();
				if (item != null)
				{
					var list = new QuoteResult
					{
						TareTotal = Convert.ToDouble(item.TareTotal),
						GVM = Convert.ToDouble(item.GVM)
					};
					qr = list;
				}
			}
		}
		return qr;
	}
