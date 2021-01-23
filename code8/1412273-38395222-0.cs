    protected void Button1_Click(object sender, EventArgs e)
    {
    PersianCalendar pc = new PersianCalendar();
    String datetime=pc.GetYear(DateTime.Now) + "/" + pc.GetMonth(DateTime.Now) + "/" + pc.GetDayOfMonth(DateTime.Now);
    String time = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
    DataSet ds = new DataSet();
    DataSetTableAdapters.tblproductTableAdapter da = new DataSetTableAdapters.tblproductTableAdapter();
    int pid;
    decimal gheymat;
    if(int.TryParse(txtprotitle.Text, out pid) &&  decimal.TryParse(txtproprice.Text, out gheymat))
    {
    da.InsertQuery(pid, txtprotitle.Text, txtexplain.Text, gheymat, txtprolink.Text, Session["userid"].ToString(), datetime, time);
    Response.Redirect("Default.aspx");}
    else{
    //error with parsing
    }
    }
