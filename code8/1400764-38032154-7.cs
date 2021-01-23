    public static String BytesToCommandLineArgument(Byte[] array)
    {            
        var ascii = Encoding.ASCII.GetString(array);
        // "Escape" it here. Disclaimer - it is actually a wrong way to escape a command line argument.
        // See https://blogs.msdn.microsoft.com/twistylittlepassagesallalike/2011/04/23/everyone-quotes-command-line-arguments-the-wrong-way/ 
        // for a way to do it correctly at least on Win32
        return String.Format("\"{0}\"", ascii); 
    }
    public static  void Main()
    {
        try
        {
            var bytes = new Byte[] { 0x10, 0x31, 0x13, 0x61, 0x20 };
            using (var process = Process.Start(
                fileName: "Buffer.exe",
                arguments: BytesToCommandLineArgument(bytes)))
            {
                process.WaitForExit();
            }
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc);
        }
        Console.WriteLine("Press any key...");
        Console.ReadKey(true);
    }
