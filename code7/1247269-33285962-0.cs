    public class AppBarButton : Button
    {
        public static readonly DependencyProperty IsActionConfirmationRequiredProperty =
            DependencyProperty.Register("IsActionConfirmationRequired", typeof(bool), typeof(AppBarButton));
    
        public static readonly DependencyProperty ActionConfirmationMessageProperty =
            DependencyProperty.Register("ActionConfirmationMessage", typeof(string), typeof(AppBarButton));
    
        public bool IsActionConfirmationRequired
        {
            get { return (bool)GetValue(IsActionConfirmationRequiredProperty); }
            set { SetValue(IsActionConfirmationRequiredProperty, value); }
        }
    
        public string ActionConfirmationMessage
        {
            get { return (string)GetValue(ActionConfirmationMessageProperty ); }
            set { SetValue(ActionConfirmationMessageProperty , value); }
        }
        
        protected override void OnClick()
        {
            bool confirmed = true;
    
            if (IsActionConfirmationRequired)
            {
                ConfirmationDailogDetails confirmationDailogDetails = new ConfirmationDailogDetails
                {
                    Message = confirmationPopUpMessage,
                    ActionName = button.Content.ToString(),
                    Template = button.Template,
                    ActionCommand = ConfirmationActionCommand
                };
    
                ConfirmationDailog dialog = new ConfirmationDailog(confirmationDailogDetails)
                {
                    PlacementTarget = button,
                    IsOpen = true
                };
    
                // Set confirmed here
    
                // If you set the DialogResult property in the ConfirmationDailog class then
    	        // confirmed = dialog.ShowDialog().Value;
            }
    
            // If there is no confirmation requred or if an user have confirmed an action
            // then call base method which will execute a command if it exists.
            if (confirmed)
            {
                base.OnClick();
            }
        }
    }
