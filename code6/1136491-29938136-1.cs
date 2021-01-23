    class User {
        private DateTime loginTime;
        private bool loggedIn;
        ..
        ..
        public DateTime LoginTime {
            get {
                if (!this.loggedIn) {
                   throw new InvalidOperationException();
                }
            }
        }
    }
