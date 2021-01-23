    Private Village _SelectedVillage;
    Public Village SelectedVillage{
    get {return _SelectedVillage;}
    set {
        _SelectedVillage = value;
        RaiseEvent myEvent();
    }
    }
