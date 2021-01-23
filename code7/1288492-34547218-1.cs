    Customer customer = null;
    try
    {
        //in this block do the stuff that is unlikely to cause exceptions
        customer = new Customer(...);
        try
        {
             //stuff that is likely to cause exceptions
        }
        catch(Exception e)
        {
             //handle likely errors
        }
    catch (Exception e)
    {
        //handle the unusual errors
    }
