    public int SelectedChargeUnitListValueId
    {
        get { return _SelectedChargeUnitListValueId; }
        set
        {
            _SelectedChargeUnitListValueId = value;
            var unitsWhere = ChargeUnits.Where(x => x.id == _SelectedChargeUnitListValueId);
            if (unitsWhere.Count() > 0)
            {
               SelectedChargeUnit = unitsWhere.First();
            }
            OnPropertyChanged("SelectedChargeUnitListValueId");
        }
    }
    public ChargeUnit SelectedChargeUnit
    {
        get { return _SelectedChargeUnit; }
        set
        {
            _SelectedChargeUnit = value;
            OnPropertyChanged("SelectedChargeUnit");
        }
    }
