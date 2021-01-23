            [HttpPost("{lastModified}")]
            public async Task<string> Upload(long lastModified)
            {
                using (var client = new HttpClient())
                {
    
                    foreach (var file in Request.Form.Files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                            var fileContent = new StreamContent(file.OpenReadStream());
                            var archiveUrl = "path to api with 2 parameters {fileName}/{lastModified}";
                            var datasetResponse = await client.PostAsync(archiveUrl, fileContent);
                            var dataset = await datasetResponse.Content.ReadAsStringAsync();
                            return dataset;
                        }
                    }
    
                    throw new ApplicationException("Cannot updated dataset to archive");
                }
            }
