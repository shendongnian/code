             spSite = new Uri(rootFolderForSharepoint);
            _spo = SpoAuthUtility.Create(spSite, sharepointUsername, WebUtility.HtmlEncode(sharepointPassword), false);
            string odataQuery = "_api/web/GetFolderByServerRelativeUrl('" + DocumentLibraryName + "/" + oldFolderUrl + "')/ListItemAllFields";
          
            byte[] content = ASCIIEncoding.ASCII.GetBytes(@"{ '__metadata':{ 'type': 'SP.Data.AccountItem' }, 'FileLeafRef': '" + newName + "' ,'Title:': '" + newName + "' }");
            string digest = _spo.GetRequestDigest();
            Uri url = new Uri(String.Format("{0}{1}", _spo.SiteUrl, odataQuery));
            // Set X-RequestDigest
            var webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            webRequest.Headers.Add("X-RequestDigest", digest);
            //Set additional Headers
            webRequest.Headers.Add("IF-MATCH", "*");
            webRequest.Headers.Add("X-HTTP-Method", "PATCH");
            // Send a json odata request to SPO rest services to fetch all list items for the list.
            byte[] result = HttpHelper.SendODataJsonRequest(
              url,
              "POST", // sending data to SP through the rest api usually uses the POST verb 
              content,
              webRequest,
              _spo // pass in the helper object that allows us to make authenticated calls to SPO rest services
              );
            string response = Encoding.UTF8.GetString(result, 0, result.Length);
            tracingservice.Trace("HTTP Response: {0}", response);
