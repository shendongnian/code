        private async Task<string> FetchUserAsync(string url)
                    {
                        try
                        {
                           // Create an HTTP web request using the URL:
                            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                            request.ContentType = "application/json";
                            request.Method = "GET";
            
                            // Send the request to the server and wait for the response:
                            using (WebResponse response = await request.GetResponseAsync())
                            {
                                // Get a stream representation of the HTTP web response:
                                using (var sr = new StreamReader(response.GetResponseStream()))
                                {
                                    string strContent = sr.ReadToEnd();
                                    return strContent;
                                }
                            }
                        }
                        catch (WebException e)
                        {
                            string a = ((HttpWebResponse)e.Response).StatusCode.ToString();
    //Toast.MakeText(this, a, ToastLength.Long).Show();
                            if (a == "GatewayTimeout")
                            {
                                return "{'errorMessage':'504: timer timed out'}";
                            }
                            else
                            {
            
                                internetDropDialog();
                                return "";
                            }
                        }
                    }
