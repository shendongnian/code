    public bool IsSelected {
        get { return isSelected; }
        set {
            isSelected = value;
            OnPropertyChanged();
            if (globalUpdate != null) globalUpdate();
        }
    }
    public ItemClass(Action globalUpdate, ...your parameters) {
        this.globalUpdate = globalUpdate;
        ...do smth with your parameters
    }
