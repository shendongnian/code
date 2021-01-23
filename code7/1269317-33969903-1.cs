        private string titleValuesDelimitedString;
        public string TitleValuesDelimitedString
        {
            get { return titleValuesDelimitedString; }
            set
            {
                string fieldComparable = this.titleValuesDelimitedString ?? string.Empty;
                string valueComparable = value ?? string.Empty;
                if (fieldComparable.Trim() != valueComparable.Trim())
                {
                    this.titleValuesDelimitedString = value;
                    this.OnPropertyChanged("TitleValuesDelimitedString");
                }
            }
        }
