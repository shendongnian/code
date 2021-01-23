	// Get previous selcetd text
    string before = Clipboard.GetText(TextDataFormat.UnicodeText);
	// Get the selected text
	Thread.Sleep(20);
	SendCtrlC(GetWindowUnderCursor());
	Thread.Sleep(30);
	label1.Text = Clipboard.GetText(TextDataFormat.UnicodeText);
	// Set the clipboard text back to the original value.
    Clipboard.SetDataObject(before, false, 10, 2000);
    // Clipboard.SetDataObject(string value, ignore this, try changing the clipboard a few times, the delay inbetween trying to chnage it in milliseconds);
