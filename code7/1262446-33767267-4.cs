    namespace UpdateUploader.Helper
    {
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            // new since 4.6 or 4.5
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
   }
