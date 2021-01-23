		public ICommand ClosingCommand { get { return new RelayCommand<CancelEventArgs>(OnClosing); } }
		private void OnClosing(CancelEventArgs args)
		{
		#if !DEBUG
			var locman = Injector.Get<LocalizationManager>();
			var dlg = Injector.Get<CustomDialogViewModel>();
			dlg.Caption = locman[LogOffCaption];
			dlg.Message = locman[LogOffPrompt];
			dlg.OnCancel = (sender) =>
			{
				args.Cancel = true;
				sender.Close();
			};
			dlg.Show();
		#endif
		}
		public ICommand ClosedCommand { get { return new RelayCommand(OnClosed); } }
		private void OnClosed()
		{
			this.Dispose();
		}
