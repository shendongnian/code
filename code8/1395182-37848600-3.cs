    public void saveData ()
    {
    SQLiteDataConnection con = new SQLiteDataConnection("yourconnectionstring");
    SQLiteDataAdapter da= new SQLiteDataAdapter("Select statement", con);
    SQLiteCommandBuiler com=new SQLiteCommandBuiler(da);
    DataSet ds= new DataSet ();
    DataTable dt = new DataTable ():
    DataRow dr;
    con.Open();
    da.fill(ds, "tablename");
    cn.Close();
    dt=ds.Tables["tablename"];
    dr=dt.NewRow();
   
    dr["rowname"]=value;
    //"same for the other rows"
    dr.Rows.Add(dr);
    da.Update(dt.Select(null, null, DataViewRowState.Added));
    }
