    using System.Diagnostic;
    
    protected void btnPing_Click(object sender, EventArgs e)
    {
         if(string.IsNullOrEmpty(txtIPAddress.Text))
              throw new ArgumentNullException();
    
         string command = @"ping " + txtIPAddress.Text;
         Process.Start("CMD.exe", command);
    }
