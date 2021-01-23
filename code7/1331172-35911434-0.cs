    private void frmInserisciCollaboratore_Load(object sender, EventArgs e)
            {
                //cmbDistaccamento.BeginUpdate();
                QueryAssist queryAssist = new QueryAssist();
                DataTable dataTable = new DataTable();
                dataTable = queryAssist.runQuery("SELECT DISTACCAMENTO.ID_Distaccamento, DISTACCAMENTO.Indirizzo FROM DISTACCAMENTO");
    
                Dictionary<int, string> comboSource = new Dictionary<int, string>();
                comboSource.Add(-1, "Select");
                foreach (DataRow dr in dataTable.Rows)
                {
                    comboSource.Add((int)dr.ItemArray[0], (string)dr.ItemArray[1]);
                }
                cmbDistaccamento.DisplayMember = "value";
                cmbDistaccamento.ValueMember = "key";
                cmbDistaccamento.DataSource = new BindingSource(comboSource, null);
                //cmbDistaccamento.EndUpdate();
            }
