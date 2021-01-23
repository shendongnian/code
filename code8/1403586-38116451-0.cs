    if (tbPerasaan2.Controls[0] == tbPerasaan2.SelectedTab) //tbPerasaan2.Controls[0] results tabpage1
    {
       for (int Tabcount = 0; Tabcount <= tbPerasaan2.SelectedIndex; Tabcount++)
       {
           DataSet ds = new DataSet();
           DataTable data = new DataTable();
           DataGridView dgJPerasaan = new DataGridView();
           //this.tbPerasaan2.SelectedTab
           TabPage t = tbPerasaan2.TabPages[0];
           tbPerasaan2.SelectedTab = t;
           t.Controls.Add(dgJPerasaan);
           //  this.Controls.Add(dgJPerasaan);
           dgJPerasaan.DataSource = data;
        }
    }
