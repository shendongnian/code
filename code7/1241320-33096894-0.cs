            string jsonResponse = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Properties.Settings.Default.MyWebService);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.Timeout = new TimeSpan(0, asyncTimeoutInMins, 0);
                    HttpResponseMessage response;
                    response = await httpClient.GetAsync("/myservice/resource");
                            
                    // Check the response StatusCode
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the content of the reqponse into a string
                        jsonResponse = await response.Content.ReadAsStringAsync();
                    }
                    else if (response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        jsonResponse = await response.Content.ReadAsStringAsync();
                        Logger.Instance.Warning(new HttpRequestException(string.Format("The response StatusCode was {0} - {1}", response.StatusCode.ToString(), jsonResponse)));
                        Environment.Exit((int)ExitCodes.Unauthorised);
                    }
                    else
                    {
                        jsonResponse = await response.Content.ReadAsStringAsync();
                        Logger.Instance.Warning(new HttpRequestException(string.Format("The response StatusCode was {0} - {1}", response.StatusCode.ToString(), jsonResponse)));
                        Environment.Exit((int)ExitCodes.ApplicationError);
                    }
               }
            }
            catch (HttpRequestException reqEx)
            {
                Logger.Instance.Error(reqEx);
                Console.WriteLine("HttpRequestException : {0}", reqEx.InnerException.Message);
                Environment.Exit((int)ExitCodes.ApplicationError);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error(ex);
                throw;
            }
            return jsonResponse;
