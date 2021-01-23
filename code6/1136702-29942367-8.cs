        // Constants
        private const Keys CopyKeys = Keys.Control | Keys.C;
        private const Keys PasteKeys = Keys.Control | Keys.V;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) 
        { 
            if((keyData == CopyKeys) || (keyData == PasteKeys))
            {
                 return true; 
            }
            else
            {
                 return base.ProcessCmdKey(ref msg, keyData);
            }
        } 
