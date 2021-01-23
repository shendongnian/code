    if (completedTask == readByteTask)
    {
      // Throw an exception if there was a read error or cancellation.
      await readByteTask;
      var byte = buf[0];
      ...
      // Continue reading
      readByteTask = stream.ReadAsync(buf, 0, 1, token);
    }
    else if (completedTask == keepAliveTimerTask)
    {
      // Throw an exception if there was a cancellation.
      await keepAliveTimerTask;
      ...
      // Restart keepalive timer.
      keepAliveTimerTask = Task.Delay(TimeSpan.FromSeconds(10), token);
    }
    else if (completedTask == messageTask)
    {
      // Throw an exception if there was a cancellation (or the SendQueue was marked as completed)
      byte[] message = await messageTask;
      ...
      // Continue reading
      messageTask = SendQueue.ReceiveAsync(token);
    }
