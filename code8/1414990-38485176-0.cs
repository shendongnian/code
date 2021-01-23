    var DLV_DOC_STEPS = new List<DLV_DOC_STEP>();
    var DLV_DOCS = new List<DLV_DOC>();
    
    foreach(...)
    {
    	foreach(...)
    	{
    		DLV_DOC_STEPS.Add(DLVSTEP);
    	}
    	
    	DLV_DOCS.Add(DOC);
    }
    
    context2.DLV_DOC_STEP.AddRange(DLV_DOC_STEPS);
    context2.DLV_DOC.AddRange(DLV_DOC);
    context2.SaveChanges
