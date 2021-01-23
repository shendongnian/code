    0    You can use below method to add data to a combobox in gridview. If you dont have a list you can add items to the combobox as 
         cmbdgv.Items.Add("Test");
        
         private void bindDataToDataGridViewCombo(){
        
        DataGridViewComboBoxColumn cmbdgv= new DataGridViewComboBoxColumn();
                    List<String> itemCodeList = new List<String>();
                        cmbdgv.DataSource = itemCodeList;
                        cmbdgv.HeaderText = "Test";
                        cmbdgv.Name = "Test";
                        cmbdgv.Width = 270;
                        cmbdgv.Columns.Add(dgvCmbForums);
                        cmbdgv.Columns["Test"].DisplayIndex = 0;
        }
        
        
        After adding if you want to capture the combobox selection change you can use below event in the datagridview.
        
          ComboBox cbm;
                DataGridViewCell currentCell;
                private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
                {
                    if (e.Control is ComboBox)
                    {
                        cbm = (ComboBox)e.Control;
                        if (cbm != null)
                        {
                            cbm.SelectedIndexChanged += new EventHandler(cbm_SelectedIndexChanged);
                        }
                        currentCell = this.dataGridView1.CurrentCell;
                    }
                }
        
                      void cbm_SelectedIndexChanged(object sender, EventArgs e)
                {
                    this.BeginInvoke(new MethodInvoker(EndEdit));
                }
        
        
                   void EndEdit()
                {
                    if (cbm != null)
                    {
                  string SelectedItem=cbm.SelectedItem.ToString();
                     int i = dataGridView1.CurrentRow.Index;
                        dataGridView1.Rows[i].Cells["Test"].Value = SelectedItem;
                    }
                 
                       
                    }
