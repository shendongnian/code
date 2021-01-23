	// UPDATE DISPLAY items (using Invoke in case call is on BW thread).
	IAsyncResult h = BeginInvoke((MethodInvoker)delegate
	{
		FooUpdown.Value = temp1;
        BarButton.Text = temp2;
	}
	);
	EndInvoke(h);  // Wait for invoke to complete.
	h.AsyncWaitHandle.Close();  // Explicitly close the wait handle.
                                // (Keeps handle count from growing until GC.)
