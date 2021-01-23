      public string FileOriginal { get; set; }
      public string  FileNew { get; set; }
      private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            FileNew = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            File.Move(FileOriginal, FileNew);
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            FileOriginal = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
