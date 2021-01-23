    var grouped = jOMACDetails.GroupBy(x => new { x.MAWorkCode, x.ConstructionNumber })
	    .Select(g => new { g, First = g.First() })
	    .Select((r, index) => new UtilityReceivingReportDetailEntity
		    {
			   DefaultAccountCode = string.IsNullOrWhiteSpace(r.First.AccountTitleCode) ? r.First.AccountTitleName.Trim() : r.First.AccountTitleCode.Trim(),
			   CompanyID = CurrentContext.CurrentCompanyID,
			   RRNumber = socnumber.Trim(),
			   RRSequenceNumber = index
		    }
        .AsEnumerable();
