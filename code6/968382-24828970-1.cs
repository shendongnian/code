        private void LoadComboLogged()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",@"\\prod\ServiceRequests");
            
            string strCon = @"Provider=Microsoft.Jet.OLEDB.4.0;DataSource=|DataDirectory|\servicereq1.mdb";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(strCon))
                {
                    conn.Open();
                    string strSql = "SELECT Initials FROM [Fixers and Testers] WHERE [Status] ='C'";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    loggedByComboBox.DataSource = ds.Tables[0];
                    loggedByComboBox.DisplayMember = "Initials";
                    loggedByComboBox.ValueMember = "Initials";
                }
            }
            catch (Exception ex)
            {
            }
        }
