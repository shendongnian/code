    string message;
    while (balloonMessages.TryDequeue(out message))
    {
         var localCopy = message;
         Console.WriteLine("Outside: {0}", localCopy);
         BeginInvoke((MethodInvoker)delegate()
         {
              Console.WriteLine("Inside: {0}", localCopy);
         });
    }
