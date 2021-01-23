    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x0112) // WM_SYSCOMMAND
        {
            if (m.WParam == new IntPtr(0xF030)) // SC_MAXIMIZE - The user clicked on the maximize button
            {
                // Change this code to manipulate your password check.
                // If the authentication fails, return: it will cancel the Maximize operation.
                if (MessageBox.Show("Maximize?", "Alert", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    // You can do stuff to tell the user about the failed authentication before returning
                    return;
                }
            }
        }
    
        // If any other operation is made, or the authentication succeeds, let it complete normally.
        base.WndProc(ref m);
    }
