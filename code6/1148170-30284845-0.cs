        private void ToggleMode(object parameter)
        {
            if (_isBasicCalculation)
            {
                _modeLabeltext = "Target profit";
                OnPropertyChanged("ModeLabelText");
                _isBasicCalculation = false;
               
            }
            else
            {
                _modeLabeltext = "Total to invest";
                OnPropertyChanged("ModeLabelText");
                _isBasicCalculation = true;
            }
          
        }
