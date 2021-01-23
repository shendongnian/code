    try
    {
        pc = new PrincipalContext(ContextType.Domain);
    }
    catch (PrincipalServerDownException ex)
    {
        //Domain is not accesible.
    }
