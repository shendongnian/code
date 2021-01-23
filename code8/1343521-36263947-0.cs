    private void btnCreate_Click(object sender, EventArgs e) {
        var filename = txtUsername.Text + ".txt";
    
        if (File.Exists(filename))
        {
            MessageBox.Show("Already used ", "Use different name");
        }
        else
        {
            System.IO.TextWriter tw = new System.IO.StreamWriter(filename);
            tw.WriteLine(txtPassword.Text);
            tw.Close();
            tw.Dispose();
            this.Close();
        }
