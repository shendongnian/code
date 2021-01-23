    private Action<T> _onCompletionAction;
    public FilterFragment(Action<T> onCompletionAction) 
    {
    	_onCompletionAction = onCompletionAction;
    }
    
    public override void OnDestroyView()
    {
    	base.OnResume();
    
    	_onCompletionAction(parameter) // parameter could be a filter object.
    }
