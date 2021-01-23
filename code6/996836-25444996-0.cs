            var url = String.Format("http://{0}.blob.core.windows.net/{1}/{2}{3}", accountName, containerName, blobName, sas);
            var request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                var response = request.GetResponse();
                context.Response.ContentType = response.ContentType;
                using (var stream = response.GetResponseStream())
                {
                    stream.CopyTo(context.Response.OutputStream);
                }
            }
            catch
            {
                context.Response.End();
            }
