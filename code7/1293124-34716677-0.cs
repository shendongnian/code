        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //check for error messages
            if (_errorRepository.ContainsErrorMessage())
                _navigationService.RequestNavigate("ContentRegion", App.Experiences.ErrorPage.ToString());
        }
