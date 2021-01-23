<!-- -->
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;
    public class ViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly PropertyErrors errors;
        private string searchText;
        public ViewModel()
        {
            this.SearchCommand = new RelayCommand(this.Search);
            this.errors = new PropertyErrors(this, this.OnErrorsChanged);
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public string SearchText
        {
            get { return this.searchText; }
            set
            {
                if (value == this.searchText)
                {
                    return;
                }
                this.searchText = value;
                this.errors.Clear(nameof(this.SearchText));
                this.OnPropertyChanged();
            }
        }
        public bool HasErrors => this.errors.HasErrors;
        public ICommand SearchCommand { get; }
        public IEnumerable GetErrors(string propertyName) => this.errors.GetErrors(propertyName);
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Search()
        {
            if (string.IsNullOrEmpty(this.searchText))
            {
                this.errors.Add(nameof(this.SearchText), "Search text cannot be empty");
                return;
            }
            MessageBox.Show("searching");
        }
        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            this.ErrorsChanged?.Invoke(this, e);
        }
    }
