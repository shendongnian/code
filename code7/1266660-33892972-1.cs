    public static void Retry()
    {
        int i = 3 - 1;
        do
        {
            try
            {
                throw new Exception();
            }
            catch (Exception) when (i < 0)
            {
                throw;
            }
            catch (Exception)
            {
                i--;
                Thread.Sleep(10);
            }
        } while (true);
    }
