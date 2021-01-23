    public void DoStuff(DataGridView dgv)
    {
        if (dgv.ReadOnly)
        {
            dgv.ReadOnly = false;
            // Load the saved ReadOnly columns.
            List<DataGridViewColumn> rocs = dgv.Tag as List<DataGridViewColumn>;
            if (rocs != null)
            {
                foreach (DataGridViewColumn roc in rocs)
                {
                    roc.ReadOnly = true;
                }
            }
            // Do related stuff.
        }
        else
        {
            // Save the ReadOnly columns before the DGV ReadOnly changes.
            List<DataGridViewColumn> rocs = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.ReadOnly)
                {
                    rocs.Add(col);
                }
            }
            dgv.Tag = rocs;
            dgv.ReadOnly = true;
            // Do other related stuff.
        }
    
        // Do common stuff.
    }
