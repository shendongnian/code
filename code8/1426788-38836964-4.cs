    public static bool? ShowDialog(CDataClass cdc)
    {
        var dlg = new DialogView();
        dlg.ViewModel.AAAVVM.CDC = cdc;
        return dlg.ShowDialog();
    }
