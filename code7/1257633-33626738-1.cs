    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        int count = 0;
        for (int i = 0; i < Application.OpenForms.Count; i++)
        {
            if (Application.OpenForms[i].Visible == true)
                count++;
        }
        if (count > 1)
        {
            if (!YesNoBox.Show("Title", "Message", this))
            {
                e.Cancel = true;
            }
        }
    }
