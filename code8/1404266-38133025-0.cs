    public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                Regex regexObj = new Regex(@"[^\d]");                
                _phoneNumber = regexObj.Replace(value, "");               
                var match = Regex.Match(_phoneNumber,  @"(\d{3})(\d{3})(\d{4})");
                if(match.Success)
                {
                    _phoneNumber = string.Format("({0}) {1}-{2}", match.Groups[1], match.Groups[2], match.Groups[3]);
                    this.Areacode = match.Groups[1].ToString();
                }
            }
        }
        private string _phoneNumber;
        public string Areacode { get; private set; }
