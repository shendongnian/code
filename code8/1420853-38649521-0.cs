       using (var client = new WebClient())
            {
                // create post parameters
                var values = new NameValueCollection();
                values["img"] = "submit";
                // get response
                var response = client.UploadValues("example.com", values);
                l.LoadHtml(Encoding.Default.GetString(response));
            }
