    catch (Exception ex)
    {
        while (ex != null)
        {
            ex = ex.InnerException;
        }
        Master.Message = ex.Message;
    }
