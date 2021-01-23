    public async Task<HttpResponseMessage> GetHttpClientResult<T>(string baseUrl, string url, T requestParam, bool isExternalLink = false,
              string acceptMediaVerb = "application/json", HttpMethod requestMethod = null)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = new HttpResponseMessage();
                    if (!isExternalLink)
                    {
                        client.BaseAddress = new Uri(baseUrl);
                    }
                    if (!string.IsNullOrEmpty(acceptMediaVerb))
                    {
                        if (acceptMediaVerb == "application/json")
                        {
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            if (requestMethod == HttpMethod.Get || requestMethod == null)
                            {
                                response = client.GetAsync(url).Result;
                            }
                            else if (requestMethod == HttpMethod.Post)
                            {
                                response = await client.PostAsJsonAsync(url, requestParam);
                            }
                        }
                    }
                    var context = new HttpContextWrapper(HttpContext.Current);
                    HttpRequestBase request = context.Request;
                    return response;
                }
                catch
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                }
            }
