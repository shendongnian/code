    Customer c = new Customer();
    
    if (customerName.Contains(" ")) {
       var terms = customerName.Split(' ');
       if (terms.Length == 2) {
          c.FirstName = terms[0];
          c.LastName = terms[1];
       }
       else { 
          //TBD
       }
    }
