    internal sealed partial class Settings
    {
        internal Settings()
        {
            this.PropertyChanged += Settings_PropertyChanged;
        }
        void Settings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("DBServer"))
                EbayListing.DBServer = this.DBServer;
            else if (e.PropertyName.Equals("DBName"))
                EbayListing.DBName = this.DBName;
        }
    }
