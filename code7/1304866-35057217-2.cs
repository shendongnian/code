    var grouped = jOMACDetails.GroupBy(x => new { x.MAWorkCode, x.ConstructionNumber })
	    .Select(g => g.First())
	    .Select((r, index) => new UtilityReceivingReportDetailEntity
		    {
			   DefaultAccountCode = string.IsNullOrWhiteSpace(r.AccountTitleCode) ? r.AccountTitleName.Trim() : r.AccountTitleCode.Trim(),
			   CompanyID = CurrentContext.CurrentCompanyID,
			   RRNumber = socnumber.Trim(),
			   RRSequenceNumber = index
		    })
        .AsEnumerable();
