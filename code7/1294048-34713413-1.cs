    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    namespace WpfApplication1
    {
        public class MainWindowViewModel1:INotifyPropertyChanged
        {
            private ObservableCollection<File> _files;
            private File _selectedFile;
            //private ICommand _getFiles;
            public ObservableCollection<File> Files
            {
                get { return _files; }
                set
                {
                    _files = value;
                    OnPropertyChanged("Files");
                }
            }
            public File SelectedFile
            {
                get { return _selectedFile; }
                set
                {
                    _selectedFile = value;
                    OnPropertyChanged("SelectedFile");
                }
            }
            //public ICommand GetFiles
            //{
            //    get { return _getFiles; }
            //    set
            //    {
            //        _getFiles = value;
            //    }
            //}
            //public void ChangeFileName(object obj)
            //{
            //    Files[0].FileName = "File_" + new Random().Next().ToString(CultureInfo.InvariantCulture);
            //}
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            public MainWindowViewModel1()
            {
               Files =  new ObservableCollection<File>();
               Files.Add(new File() { FileName = "picture", DataType = "jpg"});
               Files.Add(new File() { FileName = "soundfile", DataType = "mp3" });
               //GetFiles = new RelayCommand(ChangeFileName, param => true);
            }
        }
    }
