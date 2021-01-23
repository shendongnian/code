    private void textBox_Validating(object sender, CancelEventArgs e)
    {
        TextBox currenttb = (TextBox)sender;
        if(currenttb.Text == "")
            MessageBox.Show(string.Format("Empty field {0 }",currenttb.Name.Substring(3)));
            e.Cancel = true;
        else
        {
            e.Cancel = false;
        }
    }
