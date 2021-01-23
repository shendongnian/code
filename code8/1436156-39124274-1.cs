    //this is a kind of event handler, we should'n 'await' on it
    async void OnClientConnectedAsync(Client client)
    {
        var token = client.GetToken();
        TaskData taskData;
        if (token != null && m_tasks.TryGetValue(token, out taskData))
        {
            await ProcessMessagesAsync(taskData);
        }
        else
        {
            taskData = new TaskData();
            token = GenerateUniqueTokenBasedOnTheClientParameters(client);
            await client.SetTokenAsync(token);
            if (m_tasks.TryAdd(token, taskData))
            {
                taskData.ProcessingTask = 
                    InitProcessingTask(
                        taskData.Messages, //will be used by the 
                        client);
                await ProcessMessagesAsync(taskData);
            }
        }
    }
    async Task ProcessMessagesAsync(TaskData taskData)
    {
        while (client.IsConnected)
        {
            var message = taskData.Messages.Take();
            await client.SendAsync(message);
        }
    }
