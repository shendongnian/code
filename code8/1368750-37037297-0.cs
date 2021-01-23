    try
    {
        dbContext.Candidates.Add(item);
        dbContext.SaveChanges();
    }
    catch (Exception)
    {
        // Handle exception
    }
    finally
    {
        dbContext.Candidates.Remove(item);
    }
