    public void TestExceptionMethod()
        {
            try
            {
                throw new UnauthorizedAccessException();
            }
            catch (UnauthorizedAccessException ex)
            {
                // Do something about the error
            }
        }
