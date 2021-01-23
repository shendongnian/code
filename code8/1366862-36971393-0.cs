        public static List<Contact> ListContacts()
        {
            var contacts = new List<Contact>();           
            using (var db = new AppDbContext())
            {
                var contactsSQL = db.Set<Contact>().FromSql("dbo.GetContacts");
                foreach (var contactSQL in contactsSQL)
                {
                    var contact = new Contact();
                    contact.ID = contactSQL.ID;
                    contact.Name = contactSQL.Name;
                    contacts.Add(contact);
                }
                return contacts;
            }
        }
