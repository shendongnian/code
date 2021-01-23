    private static bool _exiting;
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!_exiting && MessageBox.Show("Are you sure want to exit?",
                           "My First Application",
                            MessageBoxButtons.OkCancel,
                            MessageBoxIcon.Information) == DialogResult.Ok)
        {
            _exiting = true;
            // this.Close(); // you don't need that, it's already closing
            Environment.Exit(1);
        }
    }
