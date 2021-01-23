      DataGridViewComboBoxColumn myCombo = new DataGridViewComboBoxColumn();
      dataGridView1.DataSource = dataSetFromDatabaseCall.Tables[0];
      myCombo.HeaderText = "My Combo";
      myCombo.Name = "myCombo";
      this.dataGridView1.Columns.Insert(1, myCombo);
      myCombo.Items.Add("test1");
      myCombo.Items.Add("test2");
      myCombo.Items.Add("test3");
     //event to check the cell value changed
     private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
     {
            if (e.ColumnIndex == myCombo.Index && e.RowIndex >= 0) //check if it is the combobox column
            {
                dataGridView1.CurrentCell.Style.BackColor = System.Drawing.Color.Yellow;
            }
     }
     private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
     {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
     }
