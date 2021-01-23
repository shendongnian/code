    public EntityBaseViewModel  SelectedEntity 
    {
        get 
    	{ 
    		return this._selectedEntity; 
    	}
        set 
    	{
            this._selectedEntity = value;
            this.NotifyOfPropertyChange(() => SelectedEntity);
        }
    }
