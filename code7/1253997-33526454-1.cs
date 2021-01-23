    public IObservable<List<Stuff>> GetGoodStuff()
    {
        return Observable.FromAsync(async cancellationToken =>
        {
            const int RetryCount = 1;
            for (int i = 0; i <= RetryCount; i++)
            {
                var accessToken = await GetAccessTokenAsync();
                var request = MakeRequest(accessToken);
                var response = await httpClient.SendAsync(request, cancellationToken);
                if (i < RetryCount && response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    InvalidateAccessToken();
                    continue;
                }
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonConvert.DeserializeObject<List<Stuff>>(json);
            }
        });
    }
