            if (cmbTMSAList.Text != "System.Data.DataRowView")
            {
                dtoTreeview.tmsaTables = cmbTMSAList.Text;
                MessageBox.Show("Name of the table: " + dtoTreeview.tmsaTables, "Information");
                TreeView1Populate();
            }
        }
