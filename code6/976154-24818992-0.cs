    private static Dictionary<int, string> items;
    //...
    lookUpEdit1.QueryPopUp += new lookUpEdit_QueryPopUp;
    lookUpEdit2.QueryPopUp += new lookUpEdit_QueryPopUp;
    //...
    private void lookUpEdit_QueryPopUp(object sender, CancelEventArgs e)
    {
        var lookUpEdit = (LookUpEdit)sender;
        lookUpEdit.Properties.DataSource = null;
        lookUpEdit.Properties.DataSource = items;
    }
