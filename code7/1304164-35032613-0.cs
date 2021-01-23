    public async Task<ActionResult> GetImage(Guid id, string random = null)
        {
            string serviceBaseUrl = Utils.GetServiceBaseUrl();
            Uri url = new Uri(string.Format("{0}{1}?id={2}", serviceBaseUrl, "api/Image", id));
            HttpResponseMessage response = await JET.Utilities.Http.SendGetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                ImageResponseModel imageResponse = JsonConvert.DeserializeObject<ImageResponseModel>(await response.Content.ReadAsStringAsync());
                System.Drawing.Image displayImage = null;
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream(imageResponse.Single.Content))
                {
                    displayImage = System.Drawing.Image.FromStream(stream);
                }
                byte[] imageBytes = ImageToByte(displayImage);
                return File(imageBytes, string.Format("image/{0}", "Png"));
            }
            return RedirectToAction("Index", "Home");
        }
