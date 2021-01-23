            try
            {
                var webAddr = "URL";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application";
                httpWebRequest.Method = "POST";
               
                string str = "request string";
                				
                httpWebRequest.Headers["Authorization"] = "";
                httpWebRequest.Headers["TenantId"] = "";
                httpWebRequest.Headers["Client-Type"] = "";
                httpWebRequest.Headers["Protocol"] = "";
                
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {                    
                    Console.WriteLine(str);
                    streamWriter.Write(str);              
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine("result=" + result);
            
                }
               
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
