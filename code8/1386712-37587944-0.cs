       private void searchButton_Click(object sender, EventArgs e)
            {
                string dataItemText;
                dataItemText = departmentCodeTextBox.Text;
                string dataNameText;
                dataNameText = departmentNameTextBox.Text;
                ListViewItem findDeptCode = showListView.FindItemWithText(dataItemText);
                ListViewItem findDeptName = showListView.FindItemWithText(dataNameText);
                if (findDeptCode!=null)
                {
                   dataNameText = findDeptName.ToString();
                   
                }
                else
                {
                    MessageBox.Show("DeparmentCode Does Not Hold");
                }
            }
