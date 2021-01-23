    private ObservableCollection<HistoryRow> _HistoryData;
    
    public ObservableCollection<HistoryRow> HistoryData 
    { 
        get 
        {
            return _HistoryData;
        }
        set 
        {
             If(Equals(_HistoryData, value) return;
            _HistoryData = value; 
            this.OnPropertyChange(nameof(this.HistoryData);
        }
    }  
