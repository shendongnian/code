    DataTable dtConnectorSource = new DataTable();
    dtConnectorSource.Columns.Add("ConnectorName", typeof(int));
    dtConnectorSource.Columns.Add("ConnectorNameDisplay", typeof(String));
        DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn ();
        cmb.DataSource = dtConnectorSource;
        cmb.DisplayMember = "ConnectorNameDisplay";
        cmb.ValueMember = "ConnectorName";
        cmb.DataPropertyName = "ConnectorName";
        dgv.Columns.Add(cmb);
