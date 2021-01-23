        public async Task<ActionResult<string>> ObtainData(string url, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                using (var httpClient = new HttpClient
                {
                    Timeout = TimeSpan.MaxValue
                })
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                    {
                        using (var response = await httpClient.SendAsync(request, ct))
                        {
                            return new ActionResult<string>()
                            {
                                Result = await HandleReceipt(response, type)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new ActionResult<string>
                {
                    Message = "Problem obtaining data. " + ex
                };
            }
        }
