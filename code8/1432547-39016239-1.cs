    private void Form1_Load(object sender, EventArgs e)
    {
        Log("start");
        var exceptionList = new List<string>();
        RunProcess(Process1, "Process1", 27, exceptionList);
        RunProcess(Process2, "Process2", 27, exceptionList);
        RunProcess(Process3, "Process3", 61, exceptionList);
        smtp(string.Join(Environment.NewLine, exceptionList));
    }
    private void RunProcess(Action processAction, string processName, int processValue,
                            ICollection<string> exceptions)
    {
        try
        {
            Log("Starting " + processName);
            processAction.Invoke();
            smtp(processName + " success");
            Log(processName + " completed");
        }
        catch (Exception e)
        {
            ExceptionLogFile(e.Message, processName, processValue, "Form1.cs");
            exceptions.Add(e.Message);
        }
    }
