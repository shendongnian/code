    List<Customer>  ListOfCustomer = new  List<Customer>  ();
    do
    {
        needToGetInputFromUser = false;
        Console.WriteLine("Please enter customer name");
        customerName = Console.ReadLine();
        if (customerName.Length < 5 ||   customerName.Length > 20)
        {
            Console.WriteLine("Invalid name length, must be between 5 and 20 characters");
            Console.WriteLine("Please try again.");
            Console.WriteLine(" ");
  
            needToGetInputFromUser = true;
        }
        else
        {
            Customer c = new Customer();
            c.Name =  customerName;
            ListOfCustomer.Add(c);
            isUserEnteredValidInputData = true;
        }
    } while (needToGetInputFromUser);
    int CustomerCount = ListOfCustomer.Count;
