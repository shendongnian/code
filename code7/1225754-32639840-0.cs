    public void Execute(IServiceProvider serviceProvider)
    {
        LocalPluginContext localcontext = new LocalPluginContext(serviceProvider);
        localcontext.Trace(string.Format(CultureInfo.InvariantCulture, "Entered {0}.Execute()", this.ChildClassName));
        try
        {
        }
        catch (FaultException<OrganizationServiceFault> e)
        {
            localcontext.Trace(string.Format(CultureInfo.InvariantCulture, "Exception: {0}", e.ToString()));
            // Handle the exception.
            throw;
        }
        finally
        {
            localcontext.Trace(string.Format(CultureInfo.InvariantCulture, "Exiting {0}.Execute()", this.ChildClassName));
        }
    }
