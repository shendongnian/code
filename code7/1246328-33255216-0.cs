    public async Task<ActionResult> SubmitPayment()
    {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://l33tpaymentgateway.com");
                var content = new FormUrlEncodedContent(new[] 
                {
                    new KeyValuePair<string, string>("MerchantCode", "12345"),
                    new KeyValuePair<string, string>("RefNo", "ABCDE"),
                    //add other properties here
                });
                var result = await client.PostAsync("", content);
                if(result.IsSuccessStatusCode)
                {
                    //Payment successfull 
                    if you need to read response content:
                    var responseContent = await result.Content.ReadAsStringAsync();                 
                }
                else
                { 
                    you got error
                } 
                
            }
    }
