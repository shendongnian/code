     private static SingleCardDetails TryGetData(IDictionary<string, object> store)
            {
                object name;
                object company;
                object designation;
                object email;
                object phone;
                store.TryGetValue("name", out name); 
                store.TryGetValue("company", out company);
                store.TryGetValue("designation", out designation);
                store.TryGetValue("email", out email);
                store.TryGetValue("phone", out phone);
    
                return new SingleCardDetails
                            {
                                Name = Convert.ToString(name),
                                Company = Convert.ToString(company),
                                Email = Convert.ToString(email),
                                Designation = Convert.ToString(designation),
                                Phone = Convert.ToString(phone)
                            };
            }
