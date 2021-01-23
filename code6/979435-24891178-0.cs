    public partial class Contact
    {
        public int ContactID { get; set; }
        public string ContactPerson { get; set; }
        public string EmailID { get; set; }
    }
    
    var _Contact=new list<Contact>();
    _Contact.add(new Contact(){ContactID=1,ContactPerson="Dev",EmailID="d@gmail.com"});
    _Contact.add(new Contact(){ContactID=2,ContactPerson="Ross",EmailID="a@gmail.com"});
    _Contact.add(new Contact(){ContactID=3,ContactPerson="Martin",EmailID="b@gmail.com"});
    _Contact.add(new Contact(){ContactID=4,ContactPerson="Moss",EmailID="c@gmail.com"});
    _Contact.add(new Contact(){ContactID=5,ContactPerson="Koos",EmailID="q@gmail.com"});
    
    // check by Primary key
    context.Contacts.AddOrUpdate(_Contacts)
    // or check by EmailID
    context.Contacts.AddOrUpdate(p => p.EmailID, _Contacts)
