    public XPCollection<LimitAllocationTotals> LimitAllocationTotals 
    {
            get
            {
                if (IsLoading || IsSaving)
                    return _LimitAllocationTotals;
                //  .... your codes
            }
    }
