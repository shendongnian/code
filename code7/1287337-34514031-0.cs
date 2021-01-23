    public static bool DownloadFile(string url, IWebDriver driver)
            {
                try
                {
                    // Construct HTTP request to get the file
                    HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpRequest.CookieContainer = new System.Net.CookieContainer();
    
                    for (int i = 0; i < driver.Manage().Cookies.AllCookies.Count - 1; i++)
                    {
                        System.Net.Cookie ck = new System.Net.Cookie(driver.Manage().Cookies.AllCookies[i].Name, driver.Manage().Cookies.AllCookies[i].Value, driver.Manage().Cookies.AllCookies[i].Path, driver.Manage().Cookies.AllCookies[i].Domain);
                        httpRequest.CookieContainer.Add(ck);
                    }
    
                    httpRequest.Accept = "text/html, application/xhtml+xml, */*";
                    httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
    
                    //HttpStatusCode responseStatus;
    
                    // Get back the HTTP response for web server
                    HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    Stream httpResponseStream = httpResponse.GetResponseStream();
    
                    // Define buffer and buffer size
                    int bufferSize = 1024;
                    byte[] buffer = new byte[bufferSize];
                    int bytesRead = 0;
    
                    // Read from response and write to file
                    FileStream fileStream = File.Create(FilePath + "\\" + FileName + ".xls");
                    while ((bytesRead = httpResponseStream.Read(buffer, 0, bufferSize)) != 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }
    
                    return true;
                }
                catch (Exception ex)
                {
                   return false;
                }
            }
