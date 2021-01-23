        public void Login()
        {
            if (_list.Contains(new Customer {Name = Username2, Pass = Password2}))
                CanLogin = true;
        }
