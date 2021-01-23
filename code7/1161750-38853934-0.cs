        private Object _selectedTab;
        public Object SelectedTab
        {
            get
            {
                return _selectedTab;
            }
            set
            {
                if (_selectedTab is ADR_Scanner.ViewModel.ConfigurationViewModel && _configurationViewModel.HasChanged)
                {
                    System.Windows.Forms.MessageBox.Show("Please save the configuration changes", ADR_Scanner.App.ResourceAssembly.GetName().Name, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                else
                {
                    _selectedTab = value;
                }
                OnPropertyChanged("SelectedTab");
            }
        }
