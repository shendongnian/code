	// Simple MsgBox:
	MessageBox.Show("Lorem Ipsum");
	// Advanced MsgBox with custom buttons
	MessageBox.Show("Lorem Ipsum", "Titel", MessageBoxButtons.OKCancel);
	MessageBox.Show("Lorem Ipsum", "Titel", MessageBoxButtons.YesNoCancel);
	// Advanced MsgBox with custom buttons and icon
	MessageBox.Show("Lorem Ipsum", "Titel", MessageBoxButtons.YesNoCancel, 
														 MessageBoxIcon.Information);
	// Check for a DialogResult
	if (MessageBox.Show("Lorem Ipsum", "Titel",
							  MessageBoxButtons.YesNo, 
							  MessageBoxIcon.Information) == DialogResult.Yes)
	{
		 // Do stuff
	}
