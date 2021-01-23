		public ShellViewModel()
		{
			utilityclass = new UtilityClass();
			utilityclass.ProgressChanged += utilityclass_ProgressChanged;
		}
		void utilityclass_ProgressChanged(object sender, UtilityClass.ProgressChangedEventHandler e)
		{
			ProgressBarValue = e.Progress;
		}
