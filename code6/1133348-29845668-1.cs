	var query = 
		from cm in db.ClientMatters
			.Include(t => t.Billing)
			.Include(t => t.Billing.Office)
			.Include(t => t.Billing.Client)
			.Include(t => t.FirmMatters)
        select cm;
			
	var clientMatters = query.AsEnumerable().Select(cm => new ClientMatterIndexListViewModel
    {
        ClientMatterID = cm.ClientMatterID,
        BillingID = cm.BillingID,
        OfficeName = cm.Billing.Office.Name,
        ClientName = cm.Billing.Client.Name,
        ClientMatterNo = cm.ClientMatterNo,
        Description = cm.Description,
        FirmMatters = Mapper.Map<ICollection<FirmMatter>, List<FirmMatterViewModel>>(cm.FirmMatters)
    });
