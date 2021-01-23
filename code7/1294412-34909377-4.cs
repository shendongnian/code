    var bytesLeftToNextFrame = 0;
    while (true)
    {
        bytes = new byte[8024000];
        int bytesRec = handler.Receive(bytes);
    
        foreach (var subscriber in Startup.Subscribers.ToList())
        {
            var theSubscriber = subscriber;
            try
            {
                if (subscriber.IsNew && bytesLeftToNextFrame < bytesRec)
                {
                    //start from the index where the new frame starts
                    await theSubscriber.WriteAsync( bytes, bytesLeftToNextFrame, bytesRec - bytesLeftToNextFrame);
                    subscriber.IsNew = false;
                }
                else
                {
                    //send everything, since we've already in streaming mode
                    await theSubscriber.WriteAsync( bytes, 0, bytesRec );
                }
            }
            catch
            {
                Startup.Subscribers.Remove(theSubscriber);
            }
        }
        //TODO: check if the current frame is done
        // then parse the next header and reset the counter.
    }
