    catch (AggregateException ae)
    {
        ae.Handle((x) =>
        {
            if (x is eConnectException) // This we know how to handle.
            {
                Console.WriteLine("Incorrect Database Name! -- " + x.Message);
            }
            
            return x is eConnectException; //rethrow anything that is not an eConnectException
        });
    }
