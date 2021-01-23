	// UPDATE DISPLAY items (using Invoke in case running on BW thread).
	IAsyncResult h = BeginInvoke((MethodInvoker)delegate
	{
		FooButton.Text = temp1;
        BarUpdown.Value = temp2;
	}
	);
	EndInvoke(h);  // Wait for invoke to complete.
	h.AsyncWaitHandle.Close();  // Explicitly close the wait handle.
                                // (Keeps handle count from growing until GC.)
