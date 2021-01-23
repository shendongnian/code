    public class MainWindow : Window {
        public void OpenWindow(bool noidea) {
            this.ShowDialog();
          
        }
        public bool CloseWindow() {
            this.Dispatcher.Invoke(() => {
                this.Dispatcher.InvokeShutdown();   // <== Important!
            });
            return true;
        }
    }
