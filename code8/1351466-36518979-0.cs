                using (HttpClient client = new HttpClient())
                {
                    var authResult = await AuthenticationHelper.Current.GetAccessTokenAsync();
                    if (authResult.Status != AuthenticationStatus.Success)
                        return;
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authResult.AccessToken);
                    Uri userPhotoEndpoint = new Uri(AuthenticationHelper.GraphEndpointId + "users/" + userIdentifier + "/Photo/$value");
                    StreamContent content = new StreamContent(image);
                    content.Headers.Add("Content-Type", "application/octet-stream");
                    using (HttpResponseMessage response = await client.PutAsync(userPhotoEndpoint, content))
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
