    public IList<KeyValuePair<int, string>> Lista
    {
        set
        {
            dgwWorkitem.DataSource = value;
            dgwWorkitem.Columns[0].HeaderText = @"Id";
            dgwWorkitem.Columns[0].Width = (((dgwWorkitem.Width) / 2) / 2);
            dgwWorkitem.Columns[1].HeaderText = @"Título";
            dgwWorkitem.Columns[1].Width = (((dgwWorkitem.Width) / 2) + ((dgwWorkitem.Width / 2) / 2));
        }
    }
