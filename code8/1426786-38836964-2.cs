    public CDataClass CDC { /* you know the drill */ }
    public void ShowDialog()
    {
        var dvm = new DialogViewModel();
        //  Maybe this isn't what you want; I don't know what CDataClass does. 
        //  But I'm assuming it has a copy constructor. 
        dvm.AAAVM.CDC = new CDataClass(this.CDC);
        if (DialogView.ShowDialog(dvm).GetValueOrDefault())
        {
            CDC = dvm.CDC;
        }
    }
