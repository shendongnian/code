    class Person
    {
        public int    Id    { get; set; }
        public string Name  { get; set; }
            
        public override string ToString()
        {
            return this.Name;
        }
    }
    class TeaParty
    {
        public DateTime Date  { get; set; }
        public Person Inviter { get; set; }
        public Person Invitee { get; set; }
        public TeaParty() { }
        public TeaParty(DateTime date, Person inviter, Person invitee) : this()
        {
            this.Date = date;
            this.Inviter = inviter;
            this.Invitee = invitee;
        }
        public bool Contains(params Person[] guests)
        {
            return guests != null && guests
                .Any(guest => this.Inviter.Id == guest.Id || this.Invitee.Id == guest.Id);
        }
        public override string ToString()
        {
            return String.Format("{0} will have tea with {1} at {2:D}", 
                this.Inviter, this.Invitee, this.Date);
        }
    }
