    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    namespace TestContacts
    {
        public enum ContactTypesEnum { 
            Family, 
            Friend, 
            Professional 
        }
        public class Contact
        {
            public int Number { get; set; }
            public string PhoneNumber { get; set; }
            public string EmailAddress { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public ContactTypesEnum Type { get; set; }
        }
        //I would suggest you check the List collection with generic data types
        //so you will be able to assign your own objects
        public class ContactCollection : List<Contact>
        {
            public Int32 ContactCount
            {
                get
                {
                    return this.Count;
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Contact c1      = new Contact();
                c1.Number       = 1; //Id?
                c1.LastName     = "Doe";
                c1.FirstName    = "John";
                c1.EmailAddress = "johndoe@email.com";
                c1.PhoneNumber  = "12345678";
                c1.Type         = ContactTypesEnum.Friend;
            
                //Create more contacts...
                //Add all contacts here
                ContactCollection contactList = new ContactCollection();
                contactList.Add(c1);
                //Loop through list
                foreach( Contact c in contactList)
                {
                    Console.WriteLine(c.FirstName); //Do something with fields
                }
                Console.ReadLine();
            }
        }
    }
