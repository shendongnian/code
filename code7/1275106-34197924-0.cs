    HttpContent bytesContent = new ByteArrayContent(ImageToBase64(fullpath));
                                    using (var client = new HttpClient())
                                    using (var formData = new MultipartFormDataContent())
                                    {
    
                                        formData.Add(new StringContent(ContentType), "Content-Type");
                                        formData.Add(new StringContent(Expires), "Expires");
                                        formData.Add(new StringContent(acl), "acl");
                                        formData.Add(new StringContent(key), "key");
                                        formData.Add(new StringContent(policy), "policy");
                                        formData.Add(new StringContent(successactionstatus), "success_action_status");
                                        formData.Add(new StringContent(xamzalgorithm), "x-amz-algorithm");
                                        formData.Add(new StringContent(xamzcredential), "x-amz-credential");
                                        formData.Add(new StringContent(xamzdate), "x-amz-date");
                                        formData.Add(new StringContent(xamzsignature), "x-amz-signature");
                                        formData.Add(bytesContent, "file", fileName);
                                        var responseTemp = client.PostAsync("https://qbprod.s3.amazonaws.com/", formData).Result;
                                        if (!responseTemp.IsSuccessStatusCode)
                                        {
                                            resultResponse.ErrorCode = "0";
                                            resultResponse.Message = "Profile Save Succesfully. But Quick Bolx Blob A/c Not Updated";
                                            resultResponse.Data = response.Response;
                                            return Ok(resultResponse);
                                        }
                                        var respon = responseTemp.Content.ReadAsStreamAsync().Result;
    
                                        if (respon != null)
                                        {
                                            var finalResponse = DeclaringFileUpload(gettokenbyuser, Quickbolxblob_id);
    
    
    ////// convert image in Base64 byte.
     public byte[] ImageToBase64(string path)
            {
                using (Image image = Image.FromFile(path))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();
    
                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        return imageBytes;
                    }
                }
            }
