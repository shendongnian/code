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
 
