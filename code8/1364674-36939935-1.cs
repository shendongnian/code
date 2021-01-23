    var request = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress, endpoint));
                SetHeaders(request);
                if (string.IsNullOrEmpty(authToken))
                {
                    throw new AuthTokenNullException();
                }
                request.Headers["Cookie"] = authToken;
                request.Method = "GET";
                HttpWebResponse response = request.GetResponseAsync().Result as HttpWebResponse;
                if (!response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    throw new HttpRequestException(string.Format("Warning expected response as 200 and got {0}", Convert.ToString(response.StatusCode)));
                }
                var reader = new StreamReader(response.GetResponseStream());
                string stringResponse = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(stringResponse);
