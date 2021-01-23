    private void button1_Click_1(object sender, EventArgs e)
    {
        String name = "Gemeinden_31.12.2011_Vergleich";
        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                       @"C:\C# tutorial Backup\Zensus_Gemeinden_org.xlsx" +
                       ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
        OleDbConnection con = new OleDbConnection(constr);
        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$D8:E11300] Where [population number] > 10000", con);
        con.Open();
        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
        DataTable data = new DataTable();
        sda.Fill(data);
        dataGridView1.DataSource = data;
        }
