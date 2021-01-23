    this.loginViewModel.StatusChanged += this.OnLoginStatusChanged;
    private void OnLoginStatusChanged(object sender, LoginStatusChangedEventArgs e)
    {
        // Do something.
        switch (e.StatusType)
        {
            ...
        }
    }
