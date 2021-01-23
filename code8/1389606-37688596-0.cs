    public static void SetBusy(bool busy, string text = null)
    {
        WindowWrapper.Current().Dispatcher.Dispatch(() =>
        {
            var modal = Window.Current.Content as ModalDialog;
            var view = modal.ModalContent as Busy;
            if (view == null)
                modal.ModalContent = view = new Busy();
            modal.IsModal = view.IsBusy = busy;
            view.BusyText = text;
            modal.CanBackButtonDismiss = true;
            // Attach to key inputs event
            var coreWindow = Window.Current.CoreWindow;
            coreWindow.CharacterReceived += CoreWindow_CharacterReceived;
        });
    }
