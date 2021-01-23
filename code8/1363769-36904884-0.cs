    /// <summary>
    /// Send a message to a specific client.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="buffer"></param>
    /// <returns></returns>
    private static async Task SendMessage(AspNetWebSocketContext context, ArraySegment<byte> buffer)
    {
        // Return control to the calling method immediately.
        await Task.Yield();
        // Make sure we have data.
        if (buffer.Count == 0)
            return;
        // The state of the connection is contained in the context Items dictionary.
        bool sending;
        lock (context)
        {
            // Are we already in the middle of a send?
            sending = (bool)context.Items["sending"];
            // If not, we are now.
            if (!sending)
                context.Items["sending"] = true;
        }
        if (!sending)
        {
            // Lock with a timeout, just in case.
            if (!Monitor.TryEnter(context.WebSocket, 1000))
            {
                // If we couldn't obtain exclusive access to the socket in one second, something is wrong.
                await context.WebSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, string.Empty, CancellationToken.None);
                return;
            }
            try
            {
                // Send the message synchronously.
                var t = context.WebSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                t.Wait();
            }
            finally
            {
                Monitor.Exit(context.WebSocket);
            }
            // Note that we've finished sending.
            lock (context)
            {
                context.Items["sending"] = false;
            }
            // Handle any queued messages.
            await HandleQueue(context);
        }
        else
        {
            // Add the message to the queue.
            lock (context)
            {
                var queue = context.Items["queue"] as List<ArraySegment<byte>>;
                if (queue == null)
                    context.Items["queue"] = queue = new List<ArraySegment<byte>>();
                queue.Add(buffer);
            }
        }
    }
    /// <summary>
    /// If there was a message in the queue for this particular web socket connection, send it.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task HandleQueue(AspNetWebSocketContext context)
    {
        var buffer = new ArraySegment<byte>();
        lock (context)
        {
            // Check for an item in the queue.
            var queue = context.Items["queue"] as List<ArraySegment<byte>>;
            if (queue != null && queue.Count > 0)
            {
                // Pull it off the top.
                buffer = queue[0];
                queue.RemoveAt(0);
            }
        }
        // Send that message.
        if (buffer.Count > 0)
            await SendMessage(context, buffer);
    }
