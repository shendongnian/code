    public class MainWindowViewModel : INotifyPropertyChanged
    {
            private bool canExecute = true;
    public ICommand openFileCommand;
    private string _myFileName;
    public string MyFileName{get{
    return _myFileName;}
    set{
    _myFileName = value;
    RaisePropertyChanged("MyFileName");
    }}
    public MainWindowViewModel()
    {
        OpenFileCommand = new RelayCommand(OpenFileCommandRun, param => this.canExecute);
    }
    public ICommand OpenFileCommand
    {
        get { return openFileCommand; }
        set { openFileCommand = value; }
    }
    public void OpenFileCommandRun(object obj)
    {
        if (obj != null)
            MessageBox.Show("OpenFileCommandRun " + obj.ToString());
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        dlg.Title = "Select My File";
        dlg.Filter = "My Files (*.csv,*.txt)|*.csv;*.txt|All Files (*.*)|*.*";
        if ((bool)dlg.ShowDialog())
        {
            // Open document 
            MyFileName = dlg.FileName; // I need the selected filename displayed in the textbox.
        }
      }
       } 
     public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    }
