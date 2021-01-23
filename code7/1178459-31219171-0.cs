    if (!_isInternalChange)
    {
        if (e.HasPropertyChanged(() => Data))
        {
            await GetValueDate(e);
        }
        else if (e.HasPropertyChanged(() => QtaDiv1) || e.HasPropertyChanged(() => Exchange))
        {
    	    using (StartInternalChange())
    		{
    			ChangeQtaDiv2(QtaDiv1, Exchange);
    		}
        }
        if (e.HasPropertyChanged(() => QtaDiv2))
        {
    	    using (StartInternalChange())
    		{	
    			ChangeQtaDiv1(QtaDiv2, Exchange);
            }
        }
        else if (e.HasPropertyChanged(() => SelectedCross))
        {
            await GetValueDate(e);
            CheckForSplitVisibility();
        }
    
        base.OnPropertyChanged(e);
    }
    
    private IDisposable StartInternalChange()
    {
        return new DisposableToken<MyClass>(this, 
    	    x => x._isInternalUpdate = false,
    		x => x._isInternalUpdate = true);
    }
