    try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("<Jira URL>/rest/api/2/issue/" + IssueKey);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.Method = "PUT";
                String username = ConfigurationManager.AppSettings["JiraUserName"];
                String password = ConfigurationManager.AppSettings["JiraPassword"];
                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
                httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);
                using (StreamWriter sw = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{" +
                                   "\"fields\" : { " +
                                   "\"timetracking\":{ \"originalEstimate\":\"12h\"  }" + 
                                   "} }";
                    sw.Write(json);
                    sw.Flush();
                    sw.Close();
                }
                using (HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    httpResponse.Close();
                }
            }
            catch (WebException ex)
            {
                WebResponse wbResponse = ex.Response;
                HttpWebResponse response = (HttpWebResponse)wbResponse;
                response.Close();
            }
