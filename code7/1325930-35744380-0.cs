    int Count = 0;
    foreach (UserRecord rec in userlist)
    {
        try
        { 
            dictionary.Add(rec.Login, rec.Group); 
        } 
        catch//(Exception ex)
        {
            //Console.WriteLine("Exception: " + ex.Message + "\nStackTrace: " + ex.Stacktrace);
        }
        finally
        {
            Count++;
        }
    }
    MessageBox.Show("Number of iterations = " + Count);
