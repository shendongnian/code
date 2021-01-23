    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            FbConnection con = new FbConnection(@"User = SYSDBA; Password = masterkey; Database = D:\TDWORK.fdb; DataSource = localhost; Port = 3050; Dialect = 3; Charset = NONE; Role = admin; Connection lifetime = 15; Pooling = true; MinPoolSize = 0; MaxPoolSize = 50; Packet Size = 8192; ServerType = 0; ");
            FbCommand cmd = new FbCommand("UPDATE OR INSERT INTO ZAPOSLENI (ZAPID, ULOGA) VALUES (" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + ", " + dataGridView1.Rows[e.RowIndex].Cells[0].Value + ") MATCHING (ZAPID)", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
