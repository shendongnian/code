    HttpWebResponse webResponse;
                using (identity.Impersonate())
                {
                    var webRequest = (HttpWebRequest)WebRequest.Create(url);
                    webResponse = (HttpWebResponse)(await webRequest.GetResponseAsync());
                }
