    public class MainForm
    {
        // Keep a reference to your popup form here, so you never create more than one instance
        private Form8 of = new Form8();
    
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (of != null && of.IsDisposed)
                of = new Form8();
            
            // Call Show(), not ShowDialog() because ShowDialog will block the UI thread
            // until you close the dialog.
            of.Show();
            of.BringToFront();
        }
    }
