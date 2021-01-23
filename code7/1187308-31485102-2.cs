    process.Start();
    new Thread(() =>
    {
        int ch;
        while ((ch = process.StandardOutput.Read()) >= 0)
        {
            // process character...for example:
            Console.Write((char)ch);
        }
    }).Start();
    process.StandardInput.WriteLine( arguments.Command );
    process.StandardInput.WriteLine( "exit" );
