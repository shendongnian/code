    class Ticket
    {
        public Ticket(string Number)
        {
            this.Number = Number;
        }
        public bool IsDone
        {
            set { _IsDone = value; }
            get { return _IsDone; }
        }
        public string Number
        {
            set { _Number = value; }
            get { return _Number; }
        }
        private bool _IsDone = false;
        private string _Number = "";
    }
