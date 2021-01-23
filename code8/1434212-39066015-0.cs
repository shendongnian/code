    IDelimitedFileEngine engine= null; // because you're programming to interfaces, right?
    switch(className)
    {
       case "Customer":
          engine = new DelimitedFileEngine<Customer>();
          break;
       case "Employee":
          engine = new DelimitedFileEngine<Employee>();
          break;
    }
