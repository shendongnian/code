    using System;
    using System.ComponentModel;
    namespace WpfApplication1.Models
    {
        public class ExpiryViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            private DateTime _expiryDate;
            public DateTime ExpiryDate { get { return _expiryDate; } set { _expiryDate = value; OnPropertyChanged("ExpiryDate"); } }
            public int SecondsToExpiry { get { return (int)ExpiryDate.Subtract(DateTime.Now).TotalSeconds; } }
            public ExpiryViewModel()
            {
                this.ExpiryDate = DateTime.Today.AddDays(2.67);
                var timer = new System.Timers.Timer(1000);
                timer.Elapsed += (s, e) => OnPropertyChanged("SecondsToExpiry");
                timer.Start();
            }
        }
    }
