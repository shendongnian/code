    foreach (var individual in xelement.Elements("LoanApp")
                                       .Elements("LoanAppRq")
                                       .Elements("Applicant")
                                       .Elements("Personal")
                                       .Elements("Individuals")
                                       .Elements("Individual"))
    {
        // Get the first and last name.
        var BORROWERFIRSTNAME = (string)individual.Elements("GivenName")
                                                  .Elements("FirstName")
                                                  .FirstOrDefault();
        var BORROWERLASTNAME = (string)individual.Elements("GivenName")
                                                 .Elements("LastName")
                                                 .FirstOrDefault();
    
        // Get the XElement for the current address.
        var currentAddress = individual.Elements("ContactInfo").Elements("Address").Where(e => (string)e.Attribute("Type") == "Current").FirstOrDefault();
        // Extract its properties, checking for a missing current address if necessary.
        var currentZip = (currentAddress == null ? null : (string)currentAddress.Element("Zip"));
    
        // Get the XElement for the previous address.
        var previousAddress = individual.Elements("ContactInfo").Elements("Address").Where(e => (string)e.Attribute("Type") == "Previous").FirstOrDefault();
        // Extract its properties, checking for a missing previous address if necessary.
        var previousZip = (previousAddress == null ? null : (string)previousAddress.Element("Zip"));
    
        // Process the borrower names and addresses as required.
    }
