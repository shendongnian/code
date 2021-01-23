    class Contact {
        public string Name{get;set;}
        public string Address {get;set;}
    }
    ...
    [HttpPost]
    public ActionResult Info(Contact payload) {
       if(contact!=null){
           var Name = contact.Name;
           var Address = contact.Address;
       }
    }
