     try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://api.shutterstock.com/v2/images/232713811?view=full");
                var username = "YourClientID";
                var password = "YourClientSecrate";
    
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
                request.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
                request.UserAgent = "MyApp 1.0";
    
                var response = (HttpWebResponse)request.GetResponse();
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
    
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var objText = reader.ReadToEnd();
                  //  Image myojb = (Image)js.Deserialize(objText, typeof(Image));             
                    var myojb = JsonConvert.DeserializeObject<RootObject>(objText);
                  
    
                    // Response.Write(reader.ReadToEnd());
                }
            }
            catch (WebException ea)    
            {
    
                Console.WriteLine(ea.Message);
                using (var stream = ea.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
