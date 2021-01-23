    private ContactList MyContact { get; set; } // MyContact is initialized with name contact
    void Clickery(object o, RoutedEventArgs e)
    {
        MyContact = new ContactList
        {
            Name = MyContact.Name + "a",
            Selected = false
        };
    }
    void Clicky(object o, RoutedEventArgs e)
    {
        string DBPath = "somefile.txt";
        List<ContactList> cl = new List<ContactList>() { 
            MyContact,
            new ContactList { Name = "contact1", Selected = false },
            new ContactList { Name = "contact2", Selected = true } };
        if (cl != null)
        {
            if (!File.Exists(DBPath))
            {
                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Contacts")
                    );
                doc.Save(DBPath);
                MessageBox.Show("File Created: " + DBPath);
            } else {
                MessageBox.Show(DBPath + " already exists!");
            }
            XDocument Doc = XDocument.Load(DBPath);
            List<XElement> elmAdd = new List<XElement>();
            XElement root = Doc.Element("Contacts");
            foreach (ContactList CL in cl)
            {
                if (root.Element(CL.Name) == null)
                {
                    if (CL.Selected == true) {
                        XElement eName = new XElement(CL.Name, "true");
                        elmAdd.Add(eName);
                    } else {
                        XElement eName = new XElement(CL.Name, "false");
                        elmAdd.Add(eName);
                    }
                }
            }
            MessageBox.Show("Lists saved");
            Doc.Element("Contacts").Add(elmAdd);
            Doc.Save(DBPath);
        } else { // End if null
            MessageBox.Show("Debug: List is empty");
        }
    } // end method
    class ContactList
    {
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
