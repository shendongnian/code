      private async Task<string> RunMessageProces()
        {
            var statusProcess = "Your message successfully inserted in process queue.";
           var retValue =  await Task.Run(() =>
            {
                lock (_oQueue)
                {
                    if (flagProcessing == true) //return when queue processing alredy started
                    {
                        return "Error"; // or some such error indicator
                    }
                    flagProcessing = true; //else start processing the queue till there are messages.
                }
                return string.Empty; // return a string here too....
            });
            // if( retValue == "Error" ) { return "Error" } 
            statusProcess = ProcessMyMessage();
            return statusProcess;
        }
