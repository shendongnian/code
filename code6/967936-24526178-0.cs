    private IEnumerable<StatusEnum> _selectedStatuses;
    public IEnumerable<StatusEnum> SelectedStatuses
    {
        get 
        {
            if (_selectedStatuses == null)
                _selectedStatuses = new List<StatusEnum>();
            return _selectedStatuses; 
        }        
    }    
