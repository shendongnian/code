    private void NavigateToOneDrivePage()
    {
        MessengerInstance.Send(new OneDriveLoginRequestMessage
        {
            CallbackAction = async () =>
            {
                // after login continue here...
                var client = SimpleIoc.Default.GetInstance<OneDriveClient>();
            }
        });
    }
