    public async Task DeployViewAsync(int itemId, string itemCode, int environmentTypeId)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
            var agents = _agentRepository.GetAgentsByitemId(itemId);
    
            var tasks = agents.Select(a =>
            {
                var viewPostRequest = new
                {
                    AgentId = a.AgentId,
                    itemCode = itemCode,
                    EnvironmentId = environmentTypeId
                };
    
                return client.PostAsJsonAsync("api/postView", viewPostRequest);
            });
    
            await Task.WhenAll(tasks);
        }
    }
