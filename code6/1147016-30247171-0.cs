    private void btnSave_Click(object sender, EventArgs e)
    {
        SaveFileDialog sfd = new SaveFileDialog();
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            using(StreamWriter write = new StreamWriter(File.Create(sfd.FileName)))
            {
                write.WriteLine(txtFirstInput.Text);
                write.WriteLine(txtSecondInput.Text);
            }
        }
    }
