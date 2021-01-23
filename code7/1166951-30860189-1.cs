     public MainDatabaseDataSet.EmployeeDataTable getData(string data)
        {
            MainDatabaseDataSetTableAdapters.EmployeeTableAdapter returnEmployee = new MainDatabaseDataSetTableAdapters.EmployeeTableAdapter();
            return returnEmployee.GetDataByName(this.textBox4.Text.Trim());
        }
     
        private void Search_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                MainDatabaseDataSet.EmployeeDataTable GetName = getData(this.Search.Text);
                MainDatabaseDataSet.EmployeeRow GetName2 = (MainDatabaseDataSet.EmployeeRow)GetName.Rows[0];
                for (int i = 0; i < GetName.Rows.Count; i++)
                {
                    DataRow drow = GetName.Rows[i];
                    if (drow.RowState != DataRowState.Deleted)
                    {
                        ListViewItem item = new ListViewItem(drow["ID"].ToString());
                        item.SubItems.Add(drow["Name"].ToString());
                        item.SubItems.Add(drow["Birthday"].ToString());
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
