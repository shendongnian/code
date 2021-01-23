        int ActiveRow = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_RowHeaderMouseClick);
        }
        void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ActiveRow = e.RowIndex;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show();
                contextMenuStrip1.Items[0].Click += new EventHandler(Copy_Click);
            }
        }
        void Copy_Click(object sender, EventArgs e)
        {
            if(ActiveRow!=null)
            Clipboard.SetText(dataGridView1.Rows[ActiveRow].Cells[0].ToString());
        }
