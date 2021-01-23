    //Data Model
    class Employee
    {
        string _firstName;
        string _lastName;
        string _address;
        string _phoneNumber;
        string _picturePath;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PicturePath { get; set; }
    }
    
    private static void InitializeDataTableFromXML(ref DataTable dataTable)
    {
            // you can read your new details from Contorls's value from your Form, then form a Enumerable collection like List<Employee> employees, and create a DataTable as folllows
            List<Employee> employees = new List<Employee>();
            // form your collection
            employees.Add(new Employee() { FirstName = "your First Name from XML File", LastName = "your Last Name from XML File or from Form Control", Address = "your new Address from Form Control or from Form Control", PhoneNumber = "your new Phone Number from Form Control", PicturePath = "your new Picture path from Form Control" });
            .
            .
            ,
            employees.Add(new Employee() { FirstName = "your First Name from XML File", LastName = "your Last Name from XML File or from Form Control", Address = "your new Address from Form Control or from Form Control", PhoneNumber = "your new Phone Number from Form Control", PicturePath = "your new Picture path from Form Control" });
            DataRow dataRow;
            foreach (var employee in employees)
            {
                dataRow = dataTable.NewRow();
                dataRow["FirstName"] = employee.FirstName;
                dataRow["LastName"] = employee.LastName;
                dataRow["Address"] = employee.Address;
                dataRow["PhoneNumber"] = employee.PhoneNumber;
                dataRow["PicturePath"] = employee.PicturePath;
                dataTable.Rows.Add(dataRow);
            }
    }
    private static void ReadOverriteXML(string xmlFilePath, DataTable dtNewXMLData)
    {
            using (XmlWriter writer = XmlWriter.Create(xmlFilePath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Employees");
                foreach (DataRow row in dtNewXMLData.Rows)
                {
                    writer.WriteStartElement("Employee");
                    writer.WriteElementString("FirstName", row["FirstName"].ToString());
                    writer.WriteElementString("LastName", row["LastName"].ToString());
                    writer.WriteElementString("Address", row["Address"].ToString());
                    writer.WriteElementString("PhoneNumber", row["PhoneNumber"].ToString());
                    writer.WriteElementString("PicturePath", row["PicturePath"].ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
    }    
    // call to the methods
    DataTable dtXML = GetDatTable();
    InitializeDataTableFromXML(ref dtXML);
    ReadOverriteXML("Employee.xml", dtXML);
   
