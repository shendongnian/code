    PrivateKey = WebConfigurationManager.AppSettings["StripeApiKey"].ToString();
                    StringBuilder postUrl = new StringBuilder();
                    postUrl.Append("&card=");
                    postUrl.Append(paymentDetail.Token);
                    postUrl.Append("&currency=USD");
                    postUrl.Append("&amount=");
                    postUrl.Append(paymentDetail.Amount);                
                    byte[] formbytes = System.Text.ASCIIEncoding.Default.GetBytes(postUrl.ToString());
                    //Create a new HTTP request object, set the method to POST and write the POST data to it
                    var webrequest = (HttpWebRequest)WebRequest.Create("https://api.stripe.com/v1/charges");
                    webrequest.Method = "POST";
                    webrequest.UserAgent = "Stripe Payment";
                    webrequest.ContentType = "application/x-www-form-urlencoded";
                    webrequest.Headers.Add("Stripe-Version", "2015-04-07");
                    webrequest.Headers.Add("Authorization", String.Concat("Basic ", (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:", this.PrivateKey))))));
    
                    using (Stream postStream = webrequest.GetRequestStream())
                    {
                        postStream.Write(formbytes, 0, formbytes.Length);
                    }
    
                    //Make the request, get a response and pull the data out of the response stream
    
                    StreamReader reader = null;
                    string stripeResponse;
                    try
                    {
                        var webresponse = (HttpWebResponse)webrequest.GetResponse();
                        Stream responseStream = webresponse.GetResponseStream();
                        reader = new StreamReader(responseStream);
                        stripeResponse = reader.ReadToEnd();
                    }
                    catch (WebException exception)
                    {
                        using (WebResponse response = exception.Response)
                        {
                            using (Stream data = response.GetResponseStream())
                            using (reader = new StreamReader(data))
                            {
                                stripeResponse = reader.ReadToEnd();                                 
                            }
                        }
                    }
