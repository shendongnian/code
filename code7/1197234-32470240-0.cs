    using Windows.Web.Http;
    using Windows.Web.Http.Filters;
    using Windows.Web.Http.Headers;
        /// <summary>
        /// Performs the post asynchronous.
        /// </summary>
        /// <typeparam name="T">The generic type parameter.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="objectToPost">The object to post.</param>
        /// <returns>The response message.</returns>
        private static async Task<HttpResponseMessage> PerformPostAsync<T>string uri, object objectToPost)
        {
            HttpResponseMessage response = null;
            // Just add default filter (to enable enterprise authentication)
            HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
            using (HttpClient client = HttpService.CreateHttpClient(filter))
            {
                // Now create the new request for the post
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(uri));
                if (objectToPost != null)
                {
                    // Frist get the bytes
                    byte[] bytes = UTF8Encoding.UTF8.GetBytes(JsonHelper.Serialize(objectToPost));
                    // Now create the HttpBufferContent from the bytes and set the request content
                    IHttpContent content = new HttpBufferContent(bytes.AsBuffer());
                    content.Headers.ContentType = HttpMediaTypeHeaderValue.Parse(HttpService.JsonMediaType);
                    request.Content = content;
                }
                // Now complete the request
                response = await client.SendRequestAsync(request);
            }
            return response;
        }
        /// <summary>
        /// Creates the HTTP client.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>HTTP client.</returns>
        private static HttpClient CreateHttpClient(HttpBaseProtocolFilter filter = null)
        {
            HttpClient client = new HttpClient(filter);
            client.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue(HttpService.JsonMediaType));
            return client;
        }
    }
