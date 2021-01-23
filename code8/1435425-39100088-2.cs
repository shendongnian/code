    SQLFunctions Lgn = new SQLFunctions();
    Lgn.ConnectionToday();
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = SQLFunctions.conn;
    
    int NumOfButtons = 40;
    int i = 1;
    
    //            int counter = 0;
    
    while ( i <= NumOfButtons)
    {
        cmd.CommandText = "SELECT id FROM Buttons where id='" + i + "'";
    
        int _bId = Int32.Parse(cmd.ExecuteScalar().ToString());
    
        Button btn = new Button();
        {
            btn.Tag = _bId;
            btn.Dock = DockStyle.Fill;
            btn.Margin = new Padding(10, 10, 10, 10);
    
            cmd.CommandText = "SELECT bName FROM Buttons where id='" + btn.Tag + "'";
            btn.Text = cmd.ExecuteScalar().ToString();
            string btn_name = cmd.ExecuteScalar().ToString();
            btn.Name = btn_name.ToString();
    
            /*                    btn.Click += delegate
             {
             pass_txt.Clear();
             username_txt.Text = btn_name;
             username_lbl.Text = btn_name;
             username_lbl.Visible = true;
             pass_txt.ReadOnly = false;
             };*/
    
        }
        cmd.CommandText = "SELECT col FROM Buttons where id='" + btn.Tag + "'";
        int btn_col = Int32.Parse(cmd.ExecuteScalar().ToString());
        //                MessageBox.Show(btn_col.ToString());
        cmd.CommandText = "SELECT row FROM Buttons where id='" + btn.Tag + "'";
        int btn_row = Int32.Parse(cmd.ExecuteScalar().ToString());
        //                MessageBox.Show(btn_row.ToString());
        tableLayoutPanel4.Controls.Add(btn, btn_col, btn_row);
    
        i++;
    
    }
    SQLFunctions.conn.Close();
