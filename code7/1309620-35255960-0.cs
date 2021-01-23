    public HttpResponseMessage PrintQualityReview([FromUri] int reviewId) {
            var reportUrl = String.Format("https://reporting.mydomain.biz/quest/_vti_bin/reportserver?https://reporting.mydomain.biz/quest/QUEST%20Reports/{0}Review.rdl&rs:Format=PDF&Review={1}",
                ConfigurationManager.AppSettings["ReportingServiceDatabase"],
                reviewId);
            CredentialCache credentialCache = new CredentialCache();
            credentialCache.Add(new Uri("https://reporting.mydomain.biz"), "NTLM", new NetworkCredential(
                ConfigurationManager.AppSettings["ReportingServiceAccount"],
                ConfigurationManager.AppSettings["ReportingServiceAccountPwd"]
            ));
            MemoryStream mStream = new MemoryStream();
            using (WebClient wc = new WebClient()) {
                wc.Credentials = credentialCache;
                using (Stream stream = wc.OpenRead(reportUrl)) {
                    stream.CopyTo(mStream);
                }
            }
            
            var contentLength = mStream.Length; //content length for header
            var contentType = new MediaTypeHeaderValue("application/pdf");
            var contentDispositionValue = "attachment; filename=Report.pdf";
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(mStream);
            response.Content.Headers.ContentType = contentType;
            response.Content.Headers.ContentLength = contentLength;
            ContentDispositionHeaderValue contentDisposition = null;            
            if (ContentDispositionHeaderValue.TryParse(contentDispositionValue , out contentDisposition)) {
                response.Content.Headers.ContentDisposition = contentDisposition;
            }
            
            return response;
        }
