        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //We know surely if this event fired there will be one selected row for sure
            //It is in the 0th index in the collection of SelectedRows
            //To access these textbox controls of form 1 inside form 2 you have to set 
            //their Modifiers to Public
            // We use the same instance of the form1 which is already opened
             clsGlobal.frm1.txtName.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
             clsGlobal.frm1.txtPhone.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
             clsGlobal.frm1.txtCountry.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
             
            //clsoe the Form2
             this.Close();
        }
 
