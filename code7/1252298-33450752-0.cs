        public bool fillComboBox(System.Windows.Controls.ComboBox combobox, string procedureName, string dTable, string dDisplay, string dValue, string defaultValue)
        {
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter sqladp = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection _sqlconTeam = new SqlConnection(DBCon.conStr))
                {
                    sqlcmd.Connection = _sqlconTeam;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = procedureName;
                    _sqlconTeam.Open();
                    sqladp.SelectCommand = sqlcmd;
                    sqladp.Fill(ds, dTable);
                    DataRow nRow = ds.Tables[dTable].NewRow();
                    nRow[dDisplay] = defaultValue;
                    nRow[dValue] = "-1";
                    ds.Tables[dTable].Rows.InsertAt(nRow, 0);
                    combobox.ItemsSource = ds.Tables[dTable].DefaultView;
                    combobox.DisplayMemberPath = ds.Tables[dTable].Columns[1].ToString();
                    combobox.SelectedValuePath = ds.Tables[dTable].Columns[0].ToString();
                    combobox.SelectedIndex = 0;
                   
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                sqladp.Dispose();
                sqlcmd.Dispose();
            }
        }
