    private void btnCalculate_Click(object sender, EventArgs e)
    {
        if(!ValidateWidth(txtWidth.Text) || 
           !ValidateLength(txtLength.Text) ||
           !ValidateDepth(txtAvgDepth.Text)) // if any of these failed
        {
            MessageBox.Show(Msg, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
