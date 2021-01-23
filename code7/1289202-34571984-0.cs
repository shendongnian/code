    class Customers
    {
        public int CustId { get; set; }
        public string Name { get; set; }
        public long MobileNo { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        internal const string XmlFileName = @"CustomersDetail.xml";
        private void AddToDB()
        {
            XDocument xdoc;
            if (!XDocumentExtensions.TryLoad(XmlFileName, out xdoc))
                // File does not exist.  Create it.
                xdoc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("LINQ To XML Demo"));
            if (xdoc.Root == null)
                xdoc.Add(new XElement("Customers"));
            xdoc.Root.Add(new XElement("Customer",
                            new XElement("CustId", CustId),
                            new XElement("Name", Name),
                            new XElement("MobileNo", MobileNo),
                            new XElement("Location", Location),
                            new XElement("Address", Address)));
            try
            {
                xdoc.Save(XmlFileName);
                Console.WriteLine("\n Added \n" + xdoc.ToString());
            }
            catch (Exception ex)
            {
                // No documented specific exception types from XDocument.Save() either.
                Debug.WriteLine(ex);
                Console.WriteLine(string.Format("Failed to write to XML file {0}", XmlFileName));
            }
        }
        // UserInput
        public void InsertCustomer()
        {
            Console.WriteLine("Enter Your Id");
            CustId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Your Mobile No");
            MobileNo = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Location");
            Location = Console.ReadLine();
            Console.WriteLine("Enter Your Address");
            Address = Console.ReadLine();
            AddToDB();
        }
    }
