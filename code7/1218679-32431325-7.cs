    private void Callback(IAsyncResult ar)
    {
      var state = (AsyncState)ar.AsyncState;
      if (ar.IsCompleted)
      {
        try
        {
            int bytesRead = state.NetworkStream.EndRead(ar);
            LogState("Post read ", state.NetworkStream);
        }
        catch (Exception ex)
        {
            Log.Warn("Exception during EndRead", ex);
            state.CancellationTokenSource.Cancel();
            return;
        }
        // Deal with the character received
        char c = (char)state.Buffer[0];
        if (c < 0)
        {
            Log.Warn("c < 0, stream closing");
            state.CancellationTokenSource.Cancel();
            return;
        }
        ... deal with the character here, building up a buffer and
        ... handing it out to the application when completed
        ... perhaps using Rx Subject<T> to make it easy to subscribe
        ... and finally ask for the next byte with the same Callback
        // Launch the next reader
        var buffer2 = new byte[1];
        var state2 = state.WithNewBuffer(buffer2);
        state.NetworkStream.BeginRead(buffer2, 0, 1, Callback, state2);
