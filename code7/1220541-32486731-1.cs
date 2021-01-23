    protected override void WndProc(ref Message m)
    {
        // 0x112: A click on one of the window buttons.
        // 0xF030: The button is the maximize button.
        // 0x00A3: The user double-clicked the title bar.
        if ((m.Msg == 0x0112 && m.WParam == new IntPtr(0xF030)) || (m.Msg == 0x00A3 && this.WindowState != FormWindowState.Maximized))
        {
            // Change this code to manipulate your password check.
            // If the authentication fails, return: it will cancel the Maximize operation.
            if (MessageBox.Show("Maximize?", "Alert", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                // You can do stuff to tell the user about the failed authentication before returning
                return;
            }
        }
    
        // If any other operation is made, or the authentication succeeds, let it complete normally.
        base.WndProc(ref m);
    }
