    public void MySyncFunction()
    {
        try
        {
            AsyncTask.Run(() => MyAsyncDriverFunction()); 
        }
        catch (Exception exp)
        {
        }
    }
