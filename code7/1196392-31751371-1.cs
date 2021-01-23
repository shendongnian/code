    protected void btnSetFinishState_Click(object sender, EventArgs e)
        {
            // if neither radio button clicked
            if (!finishyes.Checked && !finishno.Checked)
            {
                finishedBlock.Visible = true; // show the radio button DIV
                //return;
            }
        }
        protected void finishno_CheckedChanged(object sender, EventArgs e)
        {
            finishedBlock.Visible = false; // hide the radio buttons
            finishno.Checked = false; // reset the no button to false
        }
        protected void finishyes_CheckedChanged(object sender, EventArgs e)
        {
            // set the finished state code
            Response.Redirect("WebForm2.aspx");
        }
