    // get rid of the try-catch, you wont need it anymore
    int userid;
    var input = Console.ReadLine();
    if (!int.TryParse(input, out userID))
    {
        Console.WriteLine("Invalid input : '{0}' is not a number", input);
        return;
    }
    
    var aquery2 = from test in context.BusinessEntityAddress
                  where test.Address.StateProvinceID == userid
                  group test.BusinessEntity.Person.LastName by new { test.BusinessEntityID, test.BusinessEntity.Person.LastName, test.BusinessEntity.Person.FirstName } into balk
                  select new
                  {
                      /* ... */
                  };
    if (!aquery2.Any())
    {
        // not found... display a message
    }
    else
    {
        // found... do stuffs
    }
