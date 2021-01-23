    Customer customer = null;
    try
    {
        customer = new Customer();
        try
        {
             //stuff that normally causes exceptions
        }
        catch(Exception e)
        {
             //handle usual errors
        }
    catch (Exception e)
    {
        //handle the unusual errors
    }
