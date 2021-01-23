    public void SomeEvent()
    {
       string value = "testTicket";
       ticket(value);
    }
    
    public static void ticket(string ticketName) // ticketName = "testTicket"
    {
       string abc = ticketName; // result : abc null
    }
