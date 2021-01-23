	private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		Console.WriteLine("Executed");
	}
	private void CommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = true;
	}
