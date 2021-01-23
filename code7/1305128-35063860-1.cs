    var x = ...; // code from using intialization
    try
    {
        ... // code inside using statement
    }
    finally
    {
        ((IDisposable)x).Dispose();
    }
