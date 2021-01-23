    public static class MyCommands
    {
        public static readonly RoutedUICommand Copy= new RoutedUICommand
                (
                        "Copy",
                        "_Copy",
                        typeof(MyCommands),
                       null
                );
        //You can define more commands here
    }
    private void CommandBinding_CanExecute(object sender,  CanExecuteRoutedEventArgs e)
    {
            e.CanExecute = true; //can check with debugger...
    }
    private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
         //Your Action   
    }
