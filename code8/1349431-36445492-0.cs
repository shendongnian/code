    private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                id = Convert.ToInt32(dgvUserList.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                SqlConnection _sqlconnection = new SqlConnection(Database.ConnectionString);
                if (_sqlconnection.State == ConnectionState.Closed || _sqlconnection.State == ConnectionState.Broken)
                {
                    _sqlconnection.Close();
                    _sqlconnection.Open();
                }
                SqlCommand _sqlcommand = new SqlCommand("SELECT * FROM Users WHERE ID='" + id + "'");
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandType = CommandType.Text;
                SqlDataAdapter _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                foreach (DataRow _datarow in _datatable.Rows)
                {
                    txtUsername.Text = _datarow["Username"].ToString();
                    txtPassword.Text = _datarow["Password"].ToString();
                }
            }
        }
