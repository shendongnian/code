    namespace Citations
    {
        public class Citation : INotifyPropertyChanged
        {
            public static Citation ParseLine(string line)
            {
                Citation cit = new Citation();
                if (string.IsNullOrEmpty(line))
                    throw new ArgumentException("Invalid argument", nameof(line));
                string[] vals = line.Split(',');
                if (vals.Length != 6)
                    throw new ArgumentOutOfRangeException(nameof(line), "Invalid format");
                cit.CitationNumber = vals[0].Trim();
                cit.PlateNumber = vals[1].Trim();
                cit.DateCreated = DateTime.Parse(vals[2].Trim());
                cit.DateExpired = DateTime.Parse(vals[3].Trim());
                cit.Status = vals[4].Trim();
                cit.Amount = Decimal.Parse(vals[5].Trim());
                return cit;
            }
            void RaisePropertyChanged(string prop)
            {
                if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            string citationNumber;
            public string CitationNumber
            {
                get
                {
                    return citationNumber;
                }
                set
                {
                    if (citationNumber != value)
                    {
                        citationNumber = value;
                        RaisePropertyChanged(nameof(CitationNumber));
                    }
                }
            }
            string plateNumber;
            public string PlateNumber
            {
                get
                {
                    return plateNumber;
                }
                set
                {
                    if (plateNumber != value)
                    {
                        plateNumber = value;
                        RaisePropertyChanged(nameof(PlateNumber));
                    }
                }
            }
            DateTime dateCreated;
            public DateTime DateCreated
            {
                get
                {
                    return dateCreated;
                }
                set
                {
                    if (dateCreated != value)
                    {
                        dateCreated = value;
                        RaisePropertyChanged(nameof(DateCreated));
                    }
                }
            }
            DateTime dateExpired;
            public DateTime DateExpired
            {
                get
                {
                    return dateExpired;
                }
                set
                {
                    if (dateExpired != value)
                    {
                        dateExpired = value;
                        RaisePropertyChanged(nameof(DateExpired));
                    }
                }
            }
            string status;
            public string Status
            {
                get
                {
                    return status;
                }
                set
                {
                    if (status != value)
                    {
                        status = value;
                        RaisePropertyChanged(nameof(Status));
                    }
                }
            }
            Decimal amount;
            public Decimal Amount
            {
                get
                {
                    return amount;
                }
                set
                {
                    if (amount != value)
                    {
                        amount = value;
                        RaisePropertyChanged(nameof(Amount));
                    }
                }
            }
        }
    }
