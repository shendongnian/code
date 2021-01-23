    public void ShowDialog()
    {
        var cdcClone = new CDataClass(this.CDC);
        if (DialogView.ShowDialog(cdcClone).GetValueOrDefault())
        {
            CDC = cdcClone;
        }
    }
