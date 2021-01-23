     public static void createContact()
            {
                Contact c1 = new Contact();
                Console.WriteLine("GetFirstName");
                c1.GetFirstName = Console.ReadLine();
                Console.WriteLine("GetLastName");
                c1.GetLastName = Console.ReadLine();
                Console.WriteLine("GetEmailAddress");
                c1.GetEmailAddress = Console.ReadLine();
                Console.WriteLine("GetPhoneNumber");
                c1.GetPhoneNumber = Console.ReadLine();
                Console.WriteLine("ContactTypes");
                c1.ContactTypes = Console.ReadLine();
    
                //Create more contacts...
    
                //Add all contacts here
                ContactCollection contactList = new ContactCollection();
                contactList.Add(c1);
    
                //Loop through list
                foreach (Contact c in contactList)
                {
                    Console.WriteLine(c.GetFirstName); //Do something with fields
                    // Save using this foreach loop to some collection where you are storing contacts or may be directly save the list.
                }
    
                Console.ReadLine();
            }
