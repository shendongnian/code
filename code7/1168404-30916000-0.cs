    public async Task<string> UploadAllDeposit()
    {
        tableSettings settings = App.ViewModelMaintenance.Setting;
    
        var q = from tableDeposit deposit in salesDB.Deposit
                where deposit.IsSync == false
                select deposit;
    
        string result  = string.Empty;
        if (q.Count() > 0)
        {
            using (var client = new HttpClient())
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
    
    			form.Add(new StringContent(token), "token");
    			
                foreach (var item in q)
                {
    				var imageForm = new ByteArrayContent(img, 0, img.Count());
    				imagenForm.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
    				
    				form.Add(imagenForm, "img", "your_image.jpg");
    				
    				HttpResponseMessage response = await client.PostAsync("URL_HERE", form);
    				
                    response.EnsureSuccessStatusCode();
                }
    			
    			client.Dispose();
    			result = response.Content.ReadAsStringAsync().Result;
            }
        }
    
        return result;
    }
