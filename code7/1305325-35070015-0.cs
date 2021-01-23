        public PersonObj GetPersonInformation(string personName, int take)
            {
                DataTable dt = _oracle.GetPersonInformation(personName);
                return dt.AsEnumerable().Select(x => 
                            new PersonObj
                            {
                                FirstName = x.Field<string>("FIRST_NAME"),
                                LastName = x.Field<string>("LAST_NAME"),
                                PhoneNumber = x.Field<string>("PHONE_NUMBER")
                            }).ToList().Take(take);
        
            }
