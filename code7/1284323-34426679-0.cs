        static void Main(string[] args) {
        try {
            TcpClient c = new TcpClient("localhost", 1234);
        }
        catch (Exception ex) {
            // thread that logs exception message to console
            Thread logger = new Thread(new ParameterizedThreadStart(PrintException));
            logger.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            logger.Start(ex);
        }
    }
    private static void PrintException(object ex) {
        Console.WriteLine("Error: " + ((Exception)ex).Message);
    }
