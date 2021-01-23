     private static async Task<string> StorePaymentCards(string accessToken, PaymentInfoModel cardDetails)
        {
            try
            {
              //my stuff
            }
            catch (WebException ex)
            {
                string text = null;
                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        text = reader.ReadToEnd();
                        Console.WriteLine(text);
                    }
                }
                return text; //ex.GetBaseException().Message;
            }
        }
