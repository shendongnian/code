    private Village _SelectedVillage;
    public Village SelectedVillage{
    get {return _SelectedVillage;}
    set {
        _SelectedVillage = value;
        RaiseEvent myEvent();
    }
    }
