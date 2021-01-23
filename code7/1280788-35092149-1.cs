    public static void SetBusy(bool busy, string text = null)
    {
        WindowWrapper.Current().Dispatcher.Dispatch(() =>
        {
            Instance.BusyView.BusyText = text;
            Instance.ModalContainer.IsModal = Instance.BusyView.IsBusy = busy;
        });
    }
