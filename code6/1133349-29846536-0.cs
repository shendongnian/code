    var clientMatters = 
        from cm in db.ClientMatters
        select new ClientMatterIndexListViewModel
        {
            ClientMatterID = cm.ClientMatterID,
            BillingID = cm.BillingID,
            OfficeName = cm.Billing.Office.Name,
            ClientName = cm.Billing.Client.Name,
            ClientMatterNo = cm.ClientMatterNo,
            Description = cm.Description,
            FirmMatters = cm.FirmMatters.Select(fm => new FirmMatterViewModel { ... } }
        };
