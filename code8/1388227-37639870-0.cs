    void Main()
    {
        var needToGetInputFromUser = false;
        var isUserEnteredValidInputData = false;
        var choice = 0;
    
        do
        {
            needToGetInputFromUser = false;
            Console.WriteLine("Please select any of the following options to continue");
            Console.WriteLine();
    
            Console.WriteLine("Press 1 : To Track Customer ");
            Console.WriteLine("Press 2 : To track Supplier");
    
            //previous implementation could throw an exception and end program
            //use this for non integer inputs
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                needToGetInputFromUser = InvalidInput();
            }
    
            if (choice == 1)
            {
                TrackCustomerData();
    
                Console.WriteLine("Would you like to track Supplier? (Y/N).");
                if (Convert.ToString(Console.ReadLine()).ToLower() == "y")
                {
                    TrackSupplierData();
                }
            }
            else if (choice == 2)
            {
                TrackSupplierData();
    
                Console.WriteLine("Would you like to track Customer? (Y/N).");
                if (Convert.ToString(Console.ReadLine()).ToLower() == "y")
                {
                    TrackCustomerData();
                }
            }
            else
            {
                //Integers that are not 1 or 2
                needToGetInputFromUser = InvalidInput();
            }
        } while (needToGetInputFromUser);
    }
    
    public bool InvalidInput()
    {
        Console.WriteLine("Please choose correct choice");
        Console.WriteLine("Would you like to re-enter choice? (Y/N).");
    
        if (Convert.ToString(Console.ReadLine()).ToLower() == "y")
        {
            return true;
        }
        return false;
    }
    
    public void TrackCustomerData()
    {
        //Some customer data work
        Console.WriteLine("Customer tracked...");
    }
    
    public void TrackSupplierData()
    {
        //come supllier data work
        Console.WriteLine("Supplier tracked...");
    }
