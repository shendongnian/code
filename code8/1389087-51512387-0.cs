        private async void SampleCode()
         {
              var client = await GetClient();
              var data = await client.GetAllTemplatesAsync(request, new 
                    CallOptions().WithDeadline(DateTime.UtcNow.AddSeconds(7)));
    
         }
        private async Task<MyGrpcClient> GetClient()
        {
            var channel = new Channel("somehost",23456, ChannelCredentials.Insecure);
            await channel.ConnectAsync(deadline: DateTime.UtcNow.AddSeconds(2));
            return new MyGrpcClient(channel);
        }
