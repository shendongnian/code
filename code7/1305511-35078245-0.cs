    private void metroButton2_Click(object sender, EventArgs e)
    {
        string connstr = "Data Source=DESKTOP-QPC780F;Initial Catalog=db_evernote;Integrated Security=True";
        DBconnection.DBconnection db = new DBconnection.DBconnection(connstr);
        db.InsertData("Pass your Data object");
}
