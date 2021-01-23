    var listOfContacts = new List<Contact>();
    using (OleDbConnection dbfCon = new OleDbConnection(dbfConstr))
    {
        dbfCon.Open();
        var dbfCmd = new OleDbCommand(@"SELECT ct_id, ct_cmpid, ct_empid,
        ct_pplid, ct_cntid, ct_pplnm, ct_date, ct_time, ct_type, ct_doneby, ct_desc
        FROM contacts", dbfCon);
        using (var myReader = dbfCmd.ExecuteReader())
        {                       
            while (myReader.Read())
            {
                var newContact = new Contact()
                {
                    ContactID = Convert.ToInt32(myReader[0]),
                    CompanyID = Convert.ToInt32(myReader[1]),
                    EmployeeID = Convert.ToInt32(myReader[2]),
                    PersonID = Convert.ToInt32(myReader[3]),
                    ContractID = Convert.ToInt32(myReader[4]),
                    PersonName = myReader[5].ToString(),
                    ContactDate = Convert.ToDateTime(myReader[6]),
                    ContactTime = Convert.ToDateTime(myReader[7]),
                    TypeOfContact = myReader[8].ToString(),
                    ContactMadeBy = myReader[9].ToString(),
                    ContactDescription = myReader[10].ToString(),                           
                };
                listOfContacts.Add(newContact);
            }
        }
    
        DataTable dTable = new DataTable();
    
        dTable.Columns.Add("ContactID");
        dTable.Columns.Add("CompanyID");
        dTable.Columns.Add("EmployeeID");
        dTable.Columns.Add("PersonID");
        dTable.Columns.Add("ContractID");
        dTable.Columns.Add("PersonName");
        dTable.Columns.Add("ContactDate");
        dTable.Columns.Add("ContactTime");
        dTable.Columns.Add("TypeOfContact");
        dTable.Columns.Add("ContactMadeBy");
        dTable.Columns.Add("ContactDescription");
    
        MessageBox.Show(listOfContacts.Count.ToString());
    
        foreach (var contact in listOfContacts)
        {
            var newRow = dTable.NewRow();
            newRow["ContactID"] = contact.ContactID;
            newRow["CompanyID"] = contact.CompanyID;
            newRow["EmployeeID"] = contact.EmployeeID;
            newRow["PersonID"] = contact.PersonID;
            newRow["ContractID"] = contact.ContractID;
            newRow["PersonName"] = contact.PersonName;
            newRow["ContactDate"] = contact.ContactDate;
            newRow["ContactTime"] = contact.ContactTime;
            newRow["TypeOfContact"] = contact.TypeOfContact;
            newRow["ContactMadeBy"] = contact.ContactMadeBy;
            newRow["ContactDescription"] = contact.ContactDescription;
    
            dTable.Rows.Add(newRow);  // YOU NEED THIS LINE TO ADD THE NEWROW TO DATATABLE
        }
    
        MessageBox.Show(dTable.Rows.Count.ToString());
