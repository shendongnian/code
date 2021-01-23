    private void SendToPrinter(string fileName, string printerName, int id, decimal documentSequence)
        {
            // use http client to make a POST to the print api
            using (var client = new HttpClient())
            {
                // compile the values string to transfer in POST
                // should finish to look something like this:
                // C:\print.pdf&PRTFTW_OFIT&ValShip-155320-1
                var values = new Dictionary<string, string>
                {
                    { "", fileName + "&" + printerName + "&ValShip-" + id + "-" + documentSequence},
                };
                
                // URL encode the values string
                var content = new FormUrlEncodedContent(values);
                // make the POST
                // DEBUG
                var response = client.PostAsync("http://localhost:54339/api/print", content);
                // retrieve the response
                var responseString = response.Result.ToString();
            }
        }
