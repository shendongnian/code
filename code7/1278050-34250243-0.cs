    private void metaName_TextChanged(object sender,EventArgs e)
    {
        TextBox ctrl = sender as TextBox;
        if(ctrl != null)
        {
             bool enable = !string.IsNullOrEmpty(ctrl.Text);
             TextBox secondOne = this.Controls
                           .OfType<TextBox>()
                           .FirstOrDefault(x => x.Name == "metaHTTPEquiv");
            if(secondOne != null)
               secondOne.Enabled = enable;
        }
    }
