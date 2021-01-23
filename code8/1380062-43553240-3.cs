	// UPDATE DISPLAY items (using Invoke in case running on BW thread).
	IAsyncResult h = BeginInvoke((MethodInvoker)delegate
	{
		if (this.IsDisposed)  // IF BackgroundWorker invoked this operation,
                              // and then UI thread closed this form,
                              // and then message loop executes this operation,
                              // (the form is disposed), so
			return;  // don't touch the form.
		FooUpdown.Value = temp1;
        BarButton.Text = temp2;
	}
	);
	EndInvoke(h);  // Wait for invoke to complete.
	h.AsyncWaitHandle.Close();  // Explicitly close the wait handle.
                                // (Keeps handle count from growing until GC.)
