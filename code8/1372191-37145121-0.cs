    public PXAction<ARInvoice> Release;
    [PXUIField(DisplayName = "Release", MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
    [PXProcessButton]
    protected virtual IEnumerable release(PXAdapter adapter)
    {
    	PXGraph.InstanceCreated.AddHandler<ARInvoiceEntry>((graph) =>
    	{
    		graph.RowPersisted.AddHandler<ARInvoice>((cache, args) =>
    		{
    			if (args.TranStatus == PXTranStatus.Completed)
    			{
    				CreateAPBill(cache);
    			}
    		});
    	});
    
    	return Base.release.Press(adapter);
    }
