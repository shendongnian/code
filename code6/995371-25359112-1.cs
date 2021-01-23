    private RadioButtonList _siaHasConvictions;
    private RadioButtonList SiaHasConvictions
    {
        get
        {
            if (this._siaHasConvictions == null)
            {
                this._siaHasConvictions = (RadioButtonList)CriminalityInformationFormViewDisposal.FindControl(ContactEntity.SIA_HASCOVICTIONS);
            }
            return this._siaHasConvictions;
        }
    }
