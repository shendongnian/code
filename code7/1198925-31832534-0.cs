            // below code is to override the back navigation
            // hardware back button press event from navigationHelper
            _GoBackCommand = new RelayCommand
                (
                    () => this.CheckGoBack(),
                    () => this.CanCheckGoBack()
                );
            navigationHelper.GoBackCommand = _GoBackCommand;
            // ---------
