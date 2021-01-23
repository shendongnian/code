    private IList<Order> selectedOrders;
    public IList<Order> SelectedOrders
    {
    	get
    	{
    		return selectedOrders;
    	}
    	set { this.RaiseAndSetIfChanged(ref selectedOrders, value); }
    }
