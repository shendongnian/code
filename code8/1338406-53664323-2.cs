    internal class MainViewModel : ViewModelBase {
    
        private ObservableCollection<string> log = new ObservableCollection<string>();
    
        public ObservableCollection<string> Log {
            get { return log; }
        }
    
        private DelegateCommand exitCommand;
    
        public ICommand ExitCommand {
    
            get {
    
                if (exitCommand == null) {
                    exitCommand = new DelegateCommand(Exit);
                }
    
                return exitCommand;
            }
        }
    
        private void Exit() {
            Application.Current.Shutdown();
        }
    
        private DelegateCommand closedCommand;
    
        public ICommand ClosedCommand {
    
            get {
    
                if (closedCommand == null) {
                    closedCommand = new DelegateCommand(Closed);
                }
    
                return closedCommand;
            }
        }
    
        private void Closed() {
            log.Add("You won't see this of course! Closed command executed");
            MessageBox.Show("Closed");
        }
    
        private DelegateCommand closingCommand;
    
        public ICommand ClosingCommand {
    
            get {
    
                if (closingCommand == null) {
                    closingCommand = new DelegateCommand(ExecuteClosing, CanExecuteClosing);
                }
    
                return closingCommand;
            }
        }
    
        private void ExecuteClosing() {
            log.Add("Closing command executed");
            MessageBox.Show("Closing");
        }
    
        private bool CanExecuteClosing() {
    
            log.Add("Closing command execution check");
    
            return MessageBox.Show("OK to close?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }
    
        private DelegateCommand cancelClosingCommand;
    
        public ICommand CancelClosingCommand {
    
            get {
    
                if (cancelClosingCommand == null) {
                    cancelClosingCommand = new DelegateCommand(CancelClosing);
                }
    
                return cancelClosingCommand;
            }
        }
    
        private void CancelClosing() {
            log.Add("CancelClosing command executed");
            MessageBox.Show("CancelClosing");
        }
    }
 
