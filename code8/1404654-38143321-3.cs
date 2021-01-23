        private Dictionary<string, string> settings // private backing field
        public Dictionary<string, string> Settings
        {
            get { return settings; }
            set
            {
                settings = value;
                SettingsJson = JsonConvert.SerializeObject(dto.Settings); // EF tracks this
            }
        }
