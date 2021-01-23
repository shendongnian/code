    var request = new Request<T>
                {
                    Ticket = ticket,
                    Data = requestData
                };
                var httpClientHandler = new OkHttpClientHandler
                {
                    UseDefaultCredentials = true,
                    AllowAutoRedirect = true,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    ClientCertificateOptions = ClientCertificateOption.Automatic
                };
                var client = new HttpClient(httpClientHandler)
                {
                    BaseAddress = new Uri(url),
                    Timeout = TimeSpan.FromSeconds(15)
                };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var jsonRequest = this.SerializeToJson(request);
                var compressedRequest = StringCompressor.CompressString(jsonRequest);
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new ByteArrayContent(compressedRequest)
                    {
                        Headers = {ContentType = new MediaTypeHeaderValue("application/json")}
                    }
                };
                var httpResponse = await client.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                client.Dispose();
                httpResponse.EnsureSuccessStatusCode();
                var compressedResponse = await httpResponse.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                httpResponse.Dispose();
                var jsonResponse = StringCompressor.DecompressString(compressedResponse);
                var jsonResponseSerializer = new DataContractJsonSerializer(typeof(Response<V>), this._knownTypes);
                Response<V> result;
                using (var jsonResponseStream = this.GenerateStreamFromString(jsonResponse))
                {
                    result = (Response<V>) jsonResponseSerializer.ReadObject(jsonResponseStream);
                }
                return result;
