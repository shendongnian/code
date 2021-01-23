        public async Task<ActionResult> Download()
        {
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                using (
                    var stream = await httpClient.GetStreamAsync(
                        "https://ckannet-storage.commondatastorage.googleapis.com/2012-10-22T184507/aft4.tsv.gz"
                        ))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.Buffer = false;
                    Response.BufferOutput = false;
                    await stream.CopyToAsync(Response.OutputStream);
                }
                return new HttpStatusCodeResult(200);
            }
        }
