    catch (Exception ex)
    {
        while (ex.InnerException != null)
        {
            ex = ex.InnerException;
        }
        Master.Message = ex.Message;
    }
