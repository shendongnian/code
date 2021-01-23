    private async void Button_Click(object sender, RoutedEventArgs e)
    {
       //Message Box.
       MessageDialog msg = new MessageDialog("Here's the content/string.", "Hello!");
       
       //Commands
       msg.Commands.Add(new UICommand("Ok", new UICommandInvokedHandler(CommandHandlers)));
       msg.Commands.Add(new UICommand("Quit", new UICommandInvokedHandler(CommandHandlers)));
       await msg.ShowAsync();
       //end.
    }
    public void CommandHandlers(IUICommand commandLabel)
    {
       var Actions = commandLabel.Label;
       switch (Actions)
       {
           //Okay Button.
           case "Ok" :
               MainpageName.Focus(Windows.UI.Xaml.FocusState.Pointer);
             break;
           //Quit Button.
           case "Quit" :
               Application.Current.Exit();
             break;
           //end.
       }
    }
    
