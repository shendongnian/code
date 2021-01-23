    public async Task<string> GetNameAync(String PhoneNumber)
        {
            return Task<string>.Factory.StartNew(() => 
          { 
             DBEntities Context = new DBEntities();
            String Name = (from x in Context.Contacts
                           where x.Number.Equals(PhoneNumber)
                           selectx.Name).FirstOrDefault();
            return Name;
          }); 
            
        }
