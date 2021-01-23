    public ICommand ShowTransactions
    {
    	get
    	{
    		return new Command(async () =>
    		{ 
    	        //THIS IS WHERE I WAS MISSING THE AWAIT!!!
    			await ((TransactionGridViewModel)transactionSubPageViewNav.BindingContext).TransactionsGrid();
    
    			await navigation.PushAsync(transactionSubPageViewNav);
    		});
    	}
