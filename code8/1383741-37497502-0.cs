    using System.Collections.Generic;
    using Syncfusion.DocIO.DLS;
    using Syncfusion.DocIO;
    
    namespace DocIO_MailMerge
    {
       class Program
       {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Maria", "Anders", "maria.Anders@example.com", "USA"));
            customers.Add(new Customer("Ana", "Trujillo", "ana.trujillp@example.com", "USA"));
            customers.Add(new Customer("Antonio", "Moreno", "antonio.moreno@example.com", "UK"));
            customers.Add(new Customer("Thomas", "Hardy", "thomas.hardy@example.com", "Mexico"));
            using (WordDocument wordDocument = new WordDocument(@"Template.docx"))
            {
                wordDocument.MailMerge.Execute(customers);
                wordDocument.Save("Result.docx", FormatType.Docx);
            }
            System.Diagnostics.Process.Start("Result.docx");
        }
    }
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MailID { get; set; }
        public string Country { get; set; }
        public Customer(string firstName, string lastName, string emailID, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            MailID = emailID;
            Country = country;
        }
    }
    }
