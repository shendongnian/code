     public void ValidateUserCredentials()
            {
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += new DoWorkEventHandler(Bgw_DoWork);
                bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
                bgw.RunWorkerAsync();
            }
            private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (IsLoginSuccessful == true)
                {
                    _controller.CloseViewModel(this);
                    _controller.InitWincollect();
                }
            }
    
            private void Bgw_DoWork(object sender, DoWorkEventArgs e)
            {
                ShowBusyIcon = true;
                IsLoginSuccessful = _controller.ValidateUserCredential();
            }
            bool _isLoginSuccessful = false;
            private bool _showBusyIcon;
    
            public bool ShowBusyIcon
            {
                get { return _showBusyIcon; }
                set { _showBusyIcon = value; NotifyPropertyChanged("ShowBusyIcon"); }
            }
    
            public bool IsLoginSuccessful
            {
                get { return _isLoginSuccessful; }
                set { _isLoginSuccessful = value; NotifyPropertyChanged("IsLoginSuccessful"); }
            }
