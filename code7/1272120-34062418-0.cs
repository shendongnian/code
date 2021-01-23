    public class Form2 : Form 
        {
    
            private DataGridViewRow dataGridViewRow;
            public Form2(DataGridViewRow row) 
            {
                dataGridViewRow = row;
            }
            private void Btn_select_Click(object sender, EventArgs e)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.dataGridViewRow.Cells[1].Value = textBox1.Text = fbd.SelectedPath;
                }
    
            }
        }
