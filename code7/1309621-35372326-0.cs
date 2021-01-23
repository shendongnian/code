            [System.Web.Http.HttpGet]
            [System.Web.Http.Route("api/print/qualityreview/{reviewId:int}")]
            public HttpResponseMessage PrintQualityReview([FromUri] int reviewId)
            {
                logger.Info("Printing quality review for QR Id {0}", reviewId);
    
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                var reportUrl = String.Format("https://example.com/quest/_vti_bin/reportserver?https://example.com/quest/QUEST%20Reports/{0}Review.rdl&rs:Format=PDF&Review={1}",
                    ConfigurationManager.AppSettings["ReportingServiceDatabase"],
                    reviewId);            
                CredentialCache credentialCache = new CredentialCache();
                credentialCache.Add(new Uri("https://example.com"), "NTLM", new NetworkCredential(
                    ConfigurationManager.AppSettings["ReportingServiceAccount"],
                    ConfigurationManager.AppSettings["ReportingServiceAccountPwd"]
                ));
    
    
                using (WebClient webClient = new WebClient())
                {
                    webClient.Credentials = credentialCache;
                    var reportStream = webClient.OpenRead(reportUrl);
    
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        reportStream.CopyTo(memoryStream);
    
                        response.Content = new ByteArrayContent(memoryStream.ToArray());  //new StreamContent(reportStream);
                        response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                        //response.Content.Headers.ContentLength = reportStream.Length;
                        response.Content.Headers.ContentDisposition.FileName = "QualityReview.pdf";
                        response.StatusCode = HttpStatusCode.OK;
    
                        return response;
                    }
                }
            }
        }
