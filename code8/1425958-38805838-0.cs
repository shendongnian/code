        public List<string> Loadbranches()
        {
            List<string> branchNames = new List<string>();
            string strquery = "select * from Expense";
            DataHandler dh = new DataHandler();
            System.Data.DataSet dsLoadData = new System.Data.DataSet();
            dsLoadData = dh.DataLoader(strquery);
            if (dsLoadData.Tables["Temp"].Rows.Count > 0)
            {
                for (int i = 0; i < dsLoadData.Tables["Temp"].Rows.Count; i++)
                {
                    branchNames.Add(dsLoadData.Tables["Temp"].Rows[i]["ExpenseID"].ToString());
                }
            }
            return branchNames;
        }
        private void Edit_User_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            foreach (string branchName in d.Loadbranches())
            {
                cbsaveuserid.Items.Add(branchName);
            }
        }
