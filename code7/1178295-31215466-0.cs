    private async Task<List<Member>> GetMembers(int id, CancellationToken token)
        {
            try
            {
                token.ThrowIfCancellationRequested();
                HttpResponseMessage response = null;
                using (HttpClient client = new HttpClient())
                {
                    response = await client.PostAsync(new Uri("http://apiendpoint"), content)
                                           .AsTask(token);
                }
                token.ThrowIfCancellationRequested();
                // Parse response and return result
            }
            catch (OperationCanceledException ocex)
            {
                return null;
            }
        }
