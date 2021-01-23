    var response = expectedResponse;
    var timer = System.Diagnostics.Stopwatch.StartNew();
    while(timer.ElapsedMilliseconds < 3001)
    {
         //Evaluate to see if you have received the response.
         if(response != null) { funcArtike2.Invoke(rfcDest); break; }
         if(timer.ElapsedMilliseconds == 3000) { throw new TimeoutException("Response was not received within three seconds."); 
    }
    // Handle the exception down here.
