    using System.ComponentModel;
    namespace WpfApplication1
    {
     public class File:INotifyPropertyChanged
     {
        private string _fileName;
        private string _dataType;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value; 
                OnPropertyChanged("FileName");
            }
        }
        public string DataType
        {
            get { return _dataType; }
            set
            {
                _dataType = value;
                OnPropertyChanged("DataType");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
     }
    }
