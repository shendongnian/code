    private async Task SendAliveMessageAsync()
    {
        const string keepAliveMessage = "{\"message\": {\"type\": \"keepalive\"}}";
        await Task.Run( () => {
            var seconds = 0;
            while (IsRunning)
            {
                if (seconds % 10 == 0)
                {
                    await new StreamWriter(_webRequest.GetRequestStream()).WriteLineAsync(keepAliveMessage);
                }
    
                await Task.Delay(1000);
                seconds++;
            }
        });
    }
