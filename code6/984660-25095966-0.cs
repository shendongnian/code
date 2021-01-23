     private async Task<HttpResponseMessage> CloneResponseAsync(HttpResponseMessage response)
            {
                var newResponse = new HttpResponseMessage(response.StatusCode);
                var ms = new MemoryStream();
                foreach (var v in response.Headers) newResponse.Headers.TryAddWithoutValidation(v.Key, v.Value);
                if (response.Content != null)
                {
                    await response.Content.CopyToAsync(ms).ConfigureAwait(false);
                    ms.Position = 0;
                    newResponse.Content = new StreamContent(ms);
    
                    foreach (var v in response.Content.Headers) newResponse.Content.Headers.TryAddWithoutValidation(v.Key, v.Value);
    
                }
                return newResponse;
            }
