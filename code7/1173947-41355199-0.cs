    string resourceUrl = "https://<BaseURL>/sites/<SubSite>/_api/web/GetFileByServerRelativeUrl('/sites/<SubSite>/Documents/New Folder/xyz.docx')";            
            
            var wreq = WebRequest.Create(resourceUrl) as HttpWebRequest;
            wreq.Headers.Remove("X-FORMS_BASED_AUTH_ACCEPTED");
            wreq.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
	    wreq.Headers.Add("X-HTTP-Method", "DELETE");
            //wreq.Headers.Add("Authorization", "Bearer " + AccessToken);
            wreq.UseDefaultCredentials = true;
            wreq.Method = "POST";
            wreq.Accept = "application/json; odata=verbose";
            wreq.Timeout = 1000000;
            wreq.AllowWriteStreamBuffering = true;
            wreq.ContentLength = 0;
            string result = string.Empty;
            string JsonResult = string.Empty;
            try
            {
                WebResponse wresp = wreq.GetResponse();}
            catch (Exception ex)
            {
                LogError(ex);
                result = ex.Message;
            }
