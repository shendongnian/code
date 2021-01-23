    var date = System.DateTime.Now;
    string prefix = date.ToString("yyMM");
    string frmno;
    IUD.Query = "Select MAX(Form_No) AS Form_No From tbl_Students";
    DataTable dtfm = IUD.FetchToDataBase();
    if (dtfm.Rows.Count > 0 && dtfm.Rows[0]["Form_No"].ToString() != string.Empty)
    {
        var max = dtfm.Rows[0]["Form_No"].ToString();
        frmno = getNext(max);
        return frmno;
    }
    else
    {
        frmno = prefix + "001";
        return frmno;
    }
