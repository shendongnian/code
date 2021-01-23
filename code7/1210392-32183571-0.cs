    public Form1()
    {
        InitializeComponent();
        OleDbConnection baglan = new OleDbConnection(@"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\d.faldu\Desktop\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\tempExcel; Extended Properties='Excel 12.0 xml;HDR=YES;'");
        baglan.Open();
        string sql = "SELECT * FROM [Sheet1$A1:A100]";
        OleDbCommand komut = new OleDbCommand(sql, baglan);
        OleDbDataReader dr = null;
        dr = komut.ExecuteReader();
        while (dr.Read())
        {
            if (!comboBox1.Items.Contains(dr[0].ToString()))
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
        }
        baglan.Close();   
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        comboBox2.Items.Clear();
            
        OleDbConnection baglan = new OleDbConnection(@"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\d.faldu\Desktop\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\tempExcel; Extended Properties='Excel 12.0 xml;HDR=YES;'");
        baglan.Open();
        string sql = "SELECT * FROM [Sheet1$B1:B100]";
        OleDbCommand komut = new OleDbCommand(sql, baglan);
        OleDbDataReader dr = null;
        dr = komut.ExecuteReader();
            
        string sql_2 = "SELECT * FROM [Sheet1$A1:A100]";
        OleDbCommand komut_2 = new OleDbCommand(sql_2, baglan);
        OleDbDataReader dr_2 = null;
        dr_2 = komut_2.ExecuteReader();
        while (dr_2.Read() && dr.Read())
        {
            if (dr_2[0].ToString() == comboBox1.SelectedItem.ToString())
            {
                if (!comboBox2.Items.Contains(dr[0].ToString()))
                {
                    comboBox2.Items.Add(dr[0].ToString());
                }
            }
        }
        baglan.Close();
    }
