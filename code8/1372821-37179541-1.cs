     internal class Customer
        {
            public string CustomerID {get; set;}
            public string Forename { get; set; }
            public string Surname { get; set; }
        }
 
    Customer user = new Customer();
    Render.FileToFile(templateFile, user, outputFile);
