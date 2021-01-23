      private void Edit_Line_Click(object sender, EventArgs e)   
      {
            Form2 frm2 = new Form2();                       frm2.Qty=this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if(frm2.ShowDialog()==DialogResult.OK)
            {
            this.dataGridView1.SelectedRows[0].Cells[0].Value = frm2.textBox1.Text;
            }
       }
