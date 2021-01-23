    public string URL_WEBOFFICE
        {
            get
            {
                return Properties.Settings.Default.WEBOFFICE_URL.Replace("***", Properties.Settings.Default.SiteName);
            }
        }
