    public async Task<bool> Authenticate()
    {
        MiscParameterViewModel.nextButtonIsEnabled = false;
        NotifyPropertyChanged("NextButtonIsEnabled");
        const string propertyKey = "Password";
        /* Call service asynchronously */
        if(MiscParameterViewModel.servServiceLoginType == ServiceLoginTypes.Windows)
        {
            if(errorKeys.ContainsKey(propertyKey))
            {
                errorsForPassword.Clear();
                errorKeys.TryRemove(propertyKey, out errorsForPassword);
                /* Raise event to tell WPF to execute the GetErrors method */
                RaiseErrorsChanged(propertyKey);
            }
            //if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordAgain))
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                errorsForPassword.Add("Login is required!");
                errorKeys.TryAdd(propertyKey, errorsForPassword);
                return false;
            }
            else
            {
                return await Task<bool>.Factory.StartNew(() => CheckCredentials(username, password, domain));
            }
        }
        return false;
    }
