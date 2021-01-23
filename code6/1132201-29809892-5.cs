    class MethodParams
    {
        private AddressBook _addressBook;
        public MethodParams(AddressBook addressBook)
        {
            _addressBook = addressBook; // this is the address book we will work with
        }
        public static void Main()
        {
            string myChoice;
            AddressBook theAddressBook = new AddressBook();
            MethodParams mp = new MethodParams(theAddressBook);
            do
            {                      
                 // ... this can all stay the same.          
            } while (myChoice != "Q" && myChoice != "q"); // Keep going until the user wants to quit
            
            // When we get here, theAddressBook still contains everything.
            // We could save it to a file.
        }
        // ... see remarks for changes below.
    }
