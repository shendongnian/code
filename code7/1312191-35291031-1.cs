      Designation objDesignation = new ...
      // Let's avoid arrow head antipattern:
      // if any of Text is significant (i.e. has non-whitespace items)  
      // then insert a designation 
      if (new [] {
            txtDesignationNumber.Text, 
            txtDesignationName.Text, 
            txtDesignationtDescription.Text}
          .Any(c => !String.IsNullOrWhiteSpace(c)) {
    
        // create and insert a Designation;
        // there's no need to expose dsgn to the outer scope
        var dsgn = new Designation() {
          DesigNo = txtDesignationNumber.Text.Trim(),
          DesigName = txtDesignationName.Text.Trim(),
          DesigDesc = txtDesignationtDescription.Text.Trim()
        };
    
        objDesignationBLL.insertDesignation(dsgn);
      }
    
      // objDesignation hasn´t been changed
      objDesignation...
    
      
