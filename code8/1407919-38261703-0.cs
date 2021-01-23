    // Update methods for each path node used in binding steps.
    private void Update_(global::UWP.BlankPage3 obj, int phase)
    {
        if (obj != null)
        {
            if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
            {
                this.Update_ViewModel(obj.ViewModel, phase);
            }
        }
    }
    private void Update_ViewModel(global::UWP.ViewModel obj, int phase)
    {
        this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
        if (obj != null)
        {
            if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
            {
                this.Update_ViewModel_Text(obj.Text, phase);
            }
        }
    }
    ...
    private global::UWP.ViewModel cache_ViewModel = null;
    public void UpdateChildListeners_ViewModel(global::UWP.ViewModel obj)
    {
        if (obj != cache_ViewModel)
        {
            if (cache_ViewModel != null)
            {
                ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel).PropertyChanged -= PropertyChanged_ViewModel;
                cache_ViewModel = null;
            }
            if (obj != null)
            {
                cache_ViewModel = obj;
                ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel;
            }
        }
    }
