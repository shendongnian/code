    public void OutputAssert(Action func)
        {
            try
            {
                func();
            }
            catch (Exception ex)
            {
                OutputToFile(ex.Message);
                throw ex;
            }            
        }
