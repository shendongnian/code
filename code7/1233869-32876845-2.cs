        public class CopyDataGridView : DataGridView
        {
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                if (keyData == (Keys.Control | Keys.C))
                {
                    StripEmptyFromCopy();
                    return false;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
