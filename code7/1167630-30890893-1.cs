    private async void gv_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GridView gvi = sender as GridView;
            MessageDialog dlg = new MessageDialog("Are you sure you want to quit you will loose all your work ?", "Warning");
            dlg.Commands.Add(new UICommand("nav-to-page1", new UICommandInvokedHandler(CommandHandler1), 0));
            dlg.Commands.Add(new UICommand("nav-to-page2", new UICommandInvokedHandler(CommandHandler1),1));
            await dlg.ShowAsync();
        }
        private void CommandHandler1(IUICommand command)
        {
           // throw new NotImplementedException();
        }
