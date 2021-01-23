    public class AppBarButton : Button
    {
        public AppBarButton()
        {
            this.PreviewMouseLeftButtonDown += AppBarButton_PreviewMouseLeftButtonDown; ;
        }
        private void AppBarButton_PreviewMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null || IsActionConfirmationRequired == false || ConfirmationActionCommand == null)
                return;
            const string defaultMessage = "Do you really want to {0}";
            string confirmationPopUpMessage = string.IsNullOrEmpty(ActionConfirmationMessage)
              ? DebugFormat.Format(defaultMessage, button.Content)
              : ActionConfirmationMessage;
            ConfirmationDailogDetails confirmationDailogDetails = new ConfirmationDailogDetails
            {
                Message = confirmationPopUpMessage,
                ActionName = button.Content.ToString(),
                Template = button.Template,
                ActionCommand = ConfirmationActionCommand
            };
            **//instead of ConfirmationActionCommand want to use base.Command**
           ConfirmationDailog dialog = new ConfirmationDailog(confirmationDailogDetails)
           {
               PlacementTarget = button,
               IsOpen = true
           };
            //validation here
            dialog.ShowDialog();
            var confirmed = dialog.IsConfirmed;
            e.Handled = confirmed;
        }
        ...
