    class yourProgram
    {
        private bool fieldIskeysMode = false;
        private void yourControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (fieldIskeysMode) // if True
            {
                if (e.KeyData == Keys.Down || e.KeyData == Keys.Up)
                {
                    // shift to next textbox maybe, to keep thing simple ? 
                }
                if (e.KeyData == Keys.Escape) fieldIskeysMode = false; // one line set to falls on esc key 
            }
        }
        private void yourControl_Activate(object sender, KeyEventArgs e)
        {
            if (!fieldIskeysMode) // if not true 
            {
                 fieldIskeysMode = true;
            }
        }
    }
