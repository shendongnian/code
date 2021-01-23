    public partial class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 dialog = new Form2();
            dialog.ShowDialog(this);
        }
        public void ClearRows() { dataGridView1.Rows.Clear(); }
    }
