        public class CopyDataGridView : DataGridView
        {
            public bool Copying { get; set; }
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                Copying = keyData == (Keys.Control | Keys.C);
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        // And in the form:
        copyDataGridView1.KeyUp += CopyDataGridView1_KeyUp;
        private void CopyDataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (copyDataGridView1.Copying)
            {
                StripEmptyFromCopy();
                copyDataGridView1.Copying = false;
                e.Handled = true;
            }
        }
