    try
    {
        await Task.Run(() => myAppClient.CreateResourceRecord());
    }
    catch (AggregateException ae)
    {
        ae.Handle((x) =>
        {
            if (x is MyApplicationException)
            {
                // Exception code
            }
        });
    }
