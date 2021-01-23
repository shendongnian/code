    private bool saveClicked = false;
    private void btnSave_click(object sender, EventArgs e)
    {
          saveClicked = true;
    }
    private void EmailNewsletter_FormClosing(object sender, FormClosingEventArgs e)
    {
        if(saveClicked)
             return;
        DialogResult dr = MsgBox.Show("Are you sure you want to dimiss this newsletter?", "Dismiss Newsletter", MsgBox.Buttons.YesNo, MsgBox.Icon.Question);
      
        if (dr == System.Windows.Forms.DialogResult.Yes)
        {
            this.Newsletter = null;
        }
        else
        {
            e.Cancel = true;
        }
    }
