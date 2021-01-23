        protected virtual void OnClick()
        {
            RoutedEventArgs newEvent = new RoutedEventArgs(ButtonBase.ClickEvent, this);
            RaiseEvent(newEvent);
 
            MS.Internal.Commands.CommandHelpers.ExecuteCommandSource(this);
        }
