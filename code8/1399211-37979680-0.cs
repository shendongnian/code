    public class Class1
    {
        public void EatException()
        {
            try
            {
                Console.WriteLine("Blarg");
            }
            catch
            { 
                //Catching everything considered harmful!
                //Are you not curious at all about exception type?
            }
        }
        public void LogExceptionWithoutRethrowing()
        {
            try
            {
                Console.WriteLine("Blarg");
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                //Exit point '}' swallows an exception!
                //Consider throwing an exception instead.	
                //(Logging without rethrowing isn't necessarily bad,
                //but I want to know where it's happening.)
            }
        }
        public void LogExceptionAndRethrowBadly()
        {
            try
            {
                Console.WriteLine("Blarg");
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                throw ex;
                //Rethrowing exception is possibly intended.
                //(Weird message, but that's fine. It still caught the
                //"throw ex" which wipes out the stacktrace.)
            }
        }
        public void LogExceptionAndRethrow()
        {
            try
            {
                Console.WriteLine("Blarg");
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                throw;
            }
        }
    }
