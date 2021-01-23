            private string _verSion = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
        public string verion
        {
            get
            {
                return _verSion;
            }
            set
            {
                _verSion = value;
                OnPropertyChanged(() => verion);
            }
        }
