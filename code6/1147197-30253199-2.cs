    // CHANGE HERE
	public void GenericFunction(Action action)
	{
		frmLoadingControl _frmLoadingControl = new frmLoadingControl();            
		_frmLoadingControl.Show(this);
		BackgroundWorker _BackgroundWorker = new BackgroundWorker();
		_BackgroundWorker.DoWork += (s, args) =>
		{
			this.Invoke(new MethodInvoker(() => this.Enabled = false));
			// CHANGE HERE
			action();
			Execute(_FunctionCode);
		};
		_BackgroundWorker.RunWorkerCompleted += (s, args) =>
		{
			_frmLoadingControl.Close();
			this.Invoke(new MethodInvoker(() => this.Enabled = true));
		};
		_BackgroundWorker.RunWorkerAsync();
	}
	private void butProcess_1_Click(...)
	{
		// CHANGE HERE
		GenericFunction(() => Process_1(int_param1, decimal_param2, datetime_param3));
	}
