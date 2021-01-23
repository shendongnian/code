        // TASK EXAMPLE
    async Task Task_MethodAsync()
    {
        // The body of an async method is expected to contain an awaited 
        // asynchronous call.
        // Task.Delay is a placeholder for actual work.
        await Task.Delay(2000);
        // Task.Delay delays the following line by two seconds.
        textBox1.Text += String.Format("\r\nSorry for the delay. . . .\r\n");
    
        // This method has no return statement, so its return type is Task.  
    }
