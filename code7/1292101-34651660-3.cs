    private static SecureString _smtpPassword;
        public static SecureString SmtpUserPassword
        {
            get
            {
                if (_smtpPassword != null)
                    return _smtpPassword;
                _smtpPassword = new SecureString();
                foreach (var c in "your password here")
                    _smtpPassword.AppendChar(c);
                _smtpPassword.MakeReadOnly();
                return _smtpPassword;
            }
        }
