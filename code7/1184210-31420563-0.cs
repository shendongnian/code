    public partial class Entity
    {
        // Dynamic property "Email"
        [global::Microsoft.OData.Client.OriginalNameAttribute("Email")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this.OnEmailChanging(value);
                this._Email = value;
                this.OnEmailChanged();
                this.OnPropertyChanged("Email");
            }
        }
    
        private string _Email;
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
    }
