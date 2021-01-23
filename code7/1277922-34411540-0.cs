     HttpWebRequest req = (HttpWebRequest)WebRequest.Create(MPGHLogin);
                    req.AllowAutoRedirect = true;
                    string cookie = "";
                    string values = "vb_login_username=" + username + "&vb_login_password=" + password
                                    + "&securitytoken=guest&"
                                    + "cookieuser=checked&"
                                    + "do=login";
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.ContentLength = values.Length;
                    CookieContainer a = new CookieContainer();
                    req.CookieContainer = a;
        
                    System.Net.ServicePointManager.Expect100Continue = false;
        
                    StreamWriter writer = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                    writer.Write(values);
                    writer.Close();
        
                    req.Timeout = 5000;
                    HttpWebResponse c;
                    try {
                        c = (HttpWebResponse)req.GetResponse(); // da response 
                    } catch(Exception e)
                    {
                        MessageBox.Show(e.Message, "Web Exception");
                        return "WebException";
                    }
        
                    foreach (Cookie cook in c.Cookies)
                    {
                        cookie = cookie + cook.ToString() + ";";
                    }
        
                    Stream resp = c.GetResponseStream();
                    StreamReader reader = new StreamReader(resp, Encoding.GetEncoding(c.CharacterSet));
                    string response = reader.ReadToEnd();
                    reader.Close();
                    reader.Dispose();
        
                    if (response.Contains("Thank you for logging in, " + username))
                    {
                        c.Dispose();
                        return cookie;
                    }
                    else
                        return "FAILED_AUTH";
