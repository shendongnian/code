       void getAllContact()
            {
                Dictionary<string, List<Contact>> contactsDic = new Dictionary<string, List<Contact>>();
                List<Contact> list = new List<Contact>();
    
                list.Add(new Contact
                {
                    ContactID = Guid.Parse("7abe6291-43f2-e411-b150-000c2975315f"),
                    Name = "Visitor 1",
                    RegID = "1",
                    MobileNumber = "1122334455",
                    Tel = "1122334455"
                }
                );
                contactsDic.Add("contacts", list);
    
                string ss = JsonConvert.SerializeObject(contactsDic);
            }
