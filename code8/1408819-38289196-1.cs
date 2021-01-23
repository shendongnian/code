    HttpWebRequest req2 = (HttpWebRequest)HttpWebRequest.Create (newUrl);
    			req2.Method = "GET";
    			req2.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
    			req2.KeepAlive = true;
    			req2.Headers.Add ("Cookie", cookie);
    			req2.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
    			req2.Headers.Add ("Upgrade-Insecure-Requests", "1");
    			req2.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.155 Safari/537.36";
    try{
    				res = (HttpWebResponse)req2.GetResponse ();
    				headers = res.Headers;
    				foreach (string key in headers.AllKeys) {
    					Console.WriteLine (key + ":" + headers.Get (key));
    				}
				using (StreamReader sr = new StreamReader(res.GetResponseStream()))
				{
					response = sr.ReadToEnd();
				}			
				Console.WriteLine (response);
			}catch(WebException ex){
				using (StreamReader sr = new StreamReader(ex.Response.GetResponseStream()))
				{
					response = sr.ReadToEnd();
				}			
				Console.WriteLine (response);
				Console.WriteLine (ex.Response);
			}
