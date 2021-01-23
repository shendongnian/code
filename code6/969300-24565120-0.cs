    [HttpGet()]
    [Route("test")]
    public async Task<string> GetValidationImage()
    {
       string base64String;
       client.BaseAddress = new Uri(TestBaseAddress);
       client.DefaultRequestHeaders.Accept.Clear();
       client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/png"));
       
       var response = await client.GetAsync(TestString);
       
       using (var ms = new MemoryStream())
       {
       	  var image = System.Drawing.Image.FromStream(await response.Content.ReadAsStreamAsync());
       	  image.Save(ms, ImageFormat.Png);
       	  var imageBytes = ms.ToArray();
       	  base64String = Convert.ToBase64String(imageBytes);
       }
       
       return base64String;
    }
