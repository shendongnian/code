    protected override void OnStart()
    {
        base.OnStart();
    
        if (WCHSBMobileApplication.Current.SuperBillObject == null)
        {
            AddSuperBill();
        }
        else
        {
            EditSuperBill();
        }
    }
