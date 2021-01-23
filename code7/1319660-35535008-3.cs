    DataReceivedEventHandler outDataHandler = (object sender, DataReceivedEventArgs e) =>
    {
        if (e.Data != null)
        {
            var senderProcess = sender as Process;
    
            if(sender == null)
                Console.Write("Sender == NULL?");
    
            if(senderProcess.HasExited)
                Console.WriteLine("Exited");
    
            count++;
            Console.WriteLine(e.Data);
    
            // e.Data != null redundant check, already everything wrapped in if(e.Data != null)
            if (e.Data.Trim().ToLower().Equals("xxx"))
            {
                senderProcess.StandardInput.Write("k");
                Console.WriteLine("Pass");
            }
        }
    };
