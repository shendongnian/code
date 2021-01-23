     private void chk_PeelTrace_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_PeelTrace.Checked) 
            {
                chk_MoveTrace.Checked = false;
            }
        }
        private void chk_MoveTrace_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_MoveTrace.Checked)
            {
                chk_PeelTrace.Checked = false;
            }
        }
