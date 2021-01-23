    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("An unexpected error has occurred");
            Exception ex = (Exception)e.ExceptionObject;
            if (ex is MyException)
            {
                Environment.Exit(10009); // my own exit codes
            }
            Environment.Exit(ex.HResult);
        }
    }
    class MyException : Exception
    {
    }
