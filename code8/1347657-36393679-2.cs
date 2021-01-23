    void Close_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        EditorViewModel viewModel = (EditorViewModel)((FrameworkElement)e.Source).DataContext;
        ICommand command = viewModel.ExitCommand;
        command.Execute(e.Parameter);
    }
