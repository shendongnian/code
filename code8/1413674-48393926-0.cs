    private string UploadFile(string filename, int CustomerID, byte[] ImageData) {
     
            string Base64String = "data:image/jpeg;base64," + Convert.ToBase64String(ImageData, 0, ImageData.Length);
            var baseAddress = new Uri("[PUT URL HERE]");
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { AllowAutoRedirect = true, UseCookies = true, CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                try {
                    
                    //ENCODE THE FORM VARIABLES DIRECTLY INTO A STRING rather than using a FormUrlEncodedContent type which has a limit on its size.	    
                    string FormStuff = string.Format("name={0}&file={1}&id={2}", filename, HttpUtility.UrlEncode(Base64String), CustomerID.ToString());
			        //THEN USE THIS STRING TO CREATE A NEW STRINGCONTENT WHICH TAKES A PARAMETER WHICH WILL FormURLEncode IT AND DOES NOT SEEM TO THROW THE SIZE ERROR
                    StringContent content = new StringContent(FormStuff, Encoding.UTF8, "application/x-www-form-urlencoded");
                    //UPLOAD
                    string url = string.Format("/ajax/customer_image_upload.php");
                    response = client.PostAsync(url, content).Result;
                    return response.Content.ToString();
                }
                catch (Exception ex) {
                    return ex.ToString();
                }
                            
            }
        }
