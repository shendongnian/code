    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Threading;
    using System.Windows;
    using WpfApplication1.Properties;
    namespace WpfApplication1.Models
    {
        public class LoginViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                if (propertyName == "SelectedCulture")
                    ChangeCulture();
            }
            private ObservableCollection<CultureInfo> _cultures;
            public ObservableCollection<CultureInfo> Cultures { get { return _cultures; } set { _cultures = value; OnPropertyChanged("Cultures"); } }
            private CultureInfo _selectedCulture;
            public CultureInfo SelectedCulture { get { return _selectedCulture; } set { _selectedCulture = value; OnPropertyChanged("SelectedCulture"); } }
            private string _username;
            public string Username { get { return _username; } set { _username = value; OnPropertyChanged("Username"); } }
            private string _password;
            public string Password { get { return _password; } set { _password = value; OnPropertyChanged("Password"); } }
            public LoginViewModel()
            {
                this.Cultures = new ObservableCollection<CultureInfo>()
                {
                    new CultureInfo("no"),
                    new CultureInfo("en"),
                    new CultureInfo("es")
                };
            }
            private void ChangeCulture()
            {
                Thread.CurrentThread.CurrentCulture = this.SelectedCulture;
                Thread.CurrentThread.CurrentUICulture = this.SelectedCulture;
                var resx = Application.Current.Resources["Resx"] as ResourcesProxy;
                resx.ChangeCulture(this.SelectedCulture);
            }
        }
    }
