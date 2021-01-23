        public string email
        {
            get { return _email; }
            set
            {
                try
                {
                    MailAddress m = new MailAddress(value);
                    this._email = value;
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Wrong email format");
                }
            }
        }
