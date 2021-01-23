    // Save to session state in a Web Forms page class.
    Session["FirstName"] = firstName;
    Session["LastName"] = lastName;
    Session["City"] = city;
    
    // Read from session state in a Web Forms page class.
    firstName = (string)(Session["FirstName"]);
    lastName = (string)(Session["LastName"]);
    city = (string)(Session["City"]);
