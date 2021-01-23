    [DataContract]
    public partial class User : INotifyPropertyChanged
    {
        private string _Username;
        [DataMember(Name="username")]
        public string Username
        {
            get
            {
                return this._Username;
            }
            set
            {
                if(this._Username != value)
                {
                    this._Username = value;
                    RaisePropertyChanged("Username");
                }
            }
        }
    }
