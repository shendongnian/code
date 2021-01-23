    internal class Program
    {
        private static void Main(string[] args)
        {
            var exitCode = 0;
            try
            {
                //do something
            }
            catch (SystemException systemEx)
            {
                //log
                exitCode = -systemEx.HResult;
            }
            catch (Exception ex)
            {
                //log
                Environment.ExitCode = int.MinValue;
            }
            Environment.ExitCode = exitCode;
        }
    }
