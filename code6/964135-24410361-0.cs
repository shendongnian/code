    int count = 0;
    /// <summary>
    /// Console message when the system adds a new execution to the schedule.
    /// </summary>
    public void PrintAddedExecution(string messageString)
    {
        Monitor.Enter(ConsoleToken);
        if (count >= Console.BufferHeight)
        {
            Console.Clear();
            count = 0;
        }
        this.PrintCurrentTime();
        System.Console.BackgroundColor = ConsoleColor.DarkBlue;
        WriteLine(string.Format(" ADDING [ {0} ] : ", messageString));
        System.Console.ResetColor();
        WriteLine(string.Format(" > exe='{0}' ", "executionDbItem.exe"));
        WriteLine(string.Format(" > cmd='{0}'", "executionDbItem.cmd"));
        WriteLine();
        //this.RepeatPrintSystemStatus();
        Monitor.Exit(ConsoleToken);
    }
    /// <summary>
    /// Prints the sequence:
    /// carriage_return + [ HH:mm ]
    /// </summary>
    private void PrintCurrentTime()
    {
        System.Console.BackgroundColor = ConsoleColor.DarkGray;
        System.Console.ForegroundColor = ConsoleColor.Black;
        System.Console.Write("[ {0:HH:mm:ss} ]", DateTime.Now);
        System.Console.ResetColor();
        System.Console.Write(" ");
    }
    // use this method to write a line so you can keep count of the
    // total number of written lines
    void WriteLine(string s = null)
    {
        Console.WriteLine(s);
        count++;
    }
