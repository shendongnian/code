    public async Task MyMethod()
    {
        DoSomething();
        try
        {   
            string emailBody = "TestBody";
            string emailSubject = "TestSubject";
            await Task.Run(()=> SendEmailAlert(arrEmailInfo));
            
            //Insert code to execute when SendEmailAlert is completed.
            //Be aware that the SynchronizationContext is not the same once you have resumed. You might not be on the main thread here
        }
        catch (Exception ex)
        {
            //Log error message
        }
    }
    private void SendEmailAlert(string[] arrEmailInfo)
    {
        MyClassX.SendAlert(arrEmailnfo[0], arrEmailnfo[1]);
    }
