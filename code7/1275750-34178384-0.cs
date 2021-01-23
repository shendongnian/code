    public void ViewQuote(Quote quote)
    {
        if (quote.CreatedOn == null)
        {
            quote.CreatedOn = DateTime.Now;
        }
        if(NewRepository == null) NewRepository = new Respository();
        NavigationHelper.NewWindow(this, new QuoteViewModel(quote, NewRepository));
    }
