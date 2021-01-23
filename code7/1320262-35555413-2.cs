    private AddInUtilities utilities;
    protected override object RequestComAddInAutomationService()
    {
       try
       {
           if (utilities == null)
           {
               utilities = new AddInUtilities();
           }
           return utilities;
        }
        catch (System.Exception ex)
        {
             // Catch your ex here
        }
    }
