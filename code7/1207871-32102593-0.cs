    using (var con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dhelm.ALLMATINC.001\Desktop\Db11.accdb"))
    {
        using (var cmd = new OleDbCommand(@"
            INSERT INTO 
                Table1(Customer,Description,Color,Status)
                VALUES(@Customer,@Description,@Color,@Status)
        ", con))
        {
            cmd.Parameters.Add(new OleDbParameter("@Customer", OleDbType.VarChar)).Value = tBox3.Text;
            cmd.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar)).Value = tBox1.Text;
            cmd.Parameters.Add(new OleDbParameter("@Color", OleDbType.VarChar)).Value = tBox12.Text;
            cmd.Parameters.Add(new OleDbParameter("@Status", OleDbType.VarChar)).Value = cBox2.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            System.Windows.Forms.MessageBox.Show("Recrod Succefully Created");
        }
    }
