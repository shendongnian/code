    private RadioButtonList _siaHasConvictions;
    private RadioButtonList SiaHasConvictions
    {
        get { return this._siaHasConvictions ?? (this._siaHasConvictions = (RadioButtonList)CriminalityInformationFormViewDisposal.FindControl(ContactEntity.SIA_HASCOVICTIONS)); }
    }
