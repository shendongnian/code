    protected class FormWithToolStripControl : Form
    {
        //Initialization of ToolStripControl will be somewhere here
    
        //And here your common code for all forms derived from this class
        public bool onTop = false;
        public bool ToggleTop()
        {
            if (onTop)
            {
                onTop = false;
                this.TopMost = false;
                keepOnTopToolStripMenuItem.Checked = false;
                return onTop;
            }
            if (!onTop)
            {
                onTop = true;
                this.TopMost = true;
                keepOnTopToolStripMenuItem.Checked = true;
                return onTop;
            }
            else return onTop;
        }
    
        private void keepOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleTop();
        } 
    }
