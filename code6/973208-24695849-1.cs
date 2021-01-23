    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            if(MessageBox.Show("Are you sure want to exit?",
                           "My First Application",
                            MessageBoxButtons.OkCancel,
                            MessageBoxIcon.Information) == DialogResult.Ok)
                Environment.Exit(1);
            else
                e.Cancel = true; // to don't close form is user change his mind
        }
        
    }
