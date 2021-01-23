        private Object _selectedTab;
        public Object SelectedTab
        {
            get
            {
                return _selectedTab;
            }
            set
            {
                if (
                      !(_selectedTab is ADR_Scanner.ViewModel.ConfigurationViewModel) || 
                      !_configurationViewModel.HasChanged ||
                      (System.Windows.Forms.MessageBox.Show("Are you sure you want to leave this page without saving the configuration changes", ADR_Scanner.App.Current.MainWindow.Title, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
                    )
                {
                    _selectedTab = value;
                }
                OnPropertyChanged("SelectedTab");
            }
        }
