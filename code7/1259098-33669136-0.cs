    public class NewAnalysisCommand : ICommand
    {
       private Dispatcher dispatcher;
       public NewAnalysisCommand()
       {
          // The command captures the dispatcher of the GUI Thread
          dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
       }
       private void updateCanExecuteChanged(object sender, NotifyCollectionChangedEventArgs e)
       {
          // With a little help of the disptacher, let's go back to the gui thread.
          dispatcher.Invoke( () => { 
                 CanExecuteChanged(this, new EventArgs()); } 
          );
       }
    }
