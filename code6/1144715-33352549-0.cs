	EstimatesQuery eq = new EstimatesQuery("es");
	ContractorsQuery cq = new ContractorsQuery("co");
	eq.Where(eq.FDDKey == FDDkey);
	eq.InnerJoin(cq).On(eq.Contractorky == cq.Contractorky);
	EstimatesCollection coll = new EstimatesCollection();
	if(coll.Load(eq))
	{
		// Then we have found at least one
	}
