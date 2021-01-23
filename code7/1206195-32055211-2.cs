    public class ToggleWidthCommand : ICommand
    {
        private MainWindow parent;
        public ToggleWidthCommand(MainWindow parent)
        {
            this.parent = parent;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            var blueOrRed = (string)parameter;
            if (blueOrRed == "Blue")
            {
                if (this.parent.BlueColumnWidth.Value == 0)
                    this.parent.BlueColumnWidth = new System.Windows.GridLength(5, System.Windows.GridUnitType.Star);
                else
                    this.parent.BlueColumnWidth = new System.Windows.GridLength(0, System.Windows.GridUnitType.Pixel);
            }
            if (blueOrRed == "Red")
            {
                if (this.parent.RedColumnWidth.Value == 0)
                    this.parent.RedColumnWidth = new System.Windows.GridLength(5, System.Windows.GridUnitType.Star);
                else
                    this.parent.RedColumnWidth = new System.Windows.GridLength(0, System.Windows.GridUnitType.Pixel);
            }
        }
    }
