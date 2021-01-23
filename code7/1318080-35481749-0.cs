    private void test()
    {
        int z;
        using (SQLiteConnection dbcon = new SQLiteConnection("Data Source=stefanauto.psa;Version=3;"))
        {
            dbcon.Open();
            using (SQLiteCommand sql = new SQLiteCommand(dbcon))
            {
                sql.CommandText = "select ID from clienti where CNP='" + cnp.Text + "'";
                z = Convert.ToInt32(sql.ExecuteScalar());
                MessageBox.Show(z.ToString());
            }
            using (SQLiteCommand sql = new SQLiteCommand(dbcon))
            {
                sql.CommandText = "insert into vandute(ID_MASINA,ID_CLIENT)values(1,2)";
                sql.ExecuteNonQuery();
            }
        }
    }
