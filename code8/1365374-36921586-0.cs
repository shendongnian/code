    [Route("add")]
            public string Post(System.Net.Http.Formatting.FormDataCollection myValue)
            {
                NameValueCollection nvc = form.ReadAsNameValueCollection();
                string value = nvc.Get("myValue");
                return string.Format("HAIAA: [{0}]", value);
            }
