    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            if (keyData == Keys.Tab)
            {
                this.SelectionLength = 0;
                this.SelectedText = new string(' ', spaces);
                return true;
            }
            if (keyData == Keys.Enter)
            {
                this.AppendText(new string('\n', 1));
                this.AppendText(new string(' ', spaces));
                
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
