    public class User : IDataErrorInfo, INotifyPropertyChanged
    {
        public string Error
        {
            get
            {
                return this["Name"];
            }
        }
