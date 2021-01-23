        //this is by no means pretty, but im using your code verbatim 
     ` public static string httpsGET(string passedweburi, string BCO)
        {
            string content = "";
            //GET method
            HttpWebRequest HttpRequest = (HttpWebRequest)WebRequest.Create(passedweburi + BCO);
            HttpRequest.Method = "GET";
            //Response
            try
            {
            HttpWebResponse response = (HttpWebResponse)HttpRequest.GetResponse();
            }
            catch(Exception ex)
            {
                return "failed";
            }
            StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8"));
            content = sr.ReadToEnd();               
            string resp = content.TrimStart('[').TrimEnd(']').TrimStart('"').TrimEnd('"');
                if (resp == "\"The request is invalid.\"")
                {
                    return "VALIDATE Me";
                }
                else
                {
                    return resp;
                }
        }
     //calling your method
            string resp = "";
            while (rt < 60)
            {
                resp = YourStaticObj.httpsGET("http://bla","bco")
                if (resp == "failed")
                {
                    Console.Writeline("Connection Timed Out");
                    Console.Writeline("Re-establishing connection...");
                    DateTime startTime = DateTime.Now;
                    while (true)
                    {
                       if (DateTime.Now.Subtract(startTime).TotalMilliseconds > 60000)
                            break;
                    }
                    rt++;
                    Console.Writeline("Retrying " + rt.ToString() + " times");
                }
                if (rt >= 60)
                {
                    Console.Writeline("Failed to reconnect.");
                } 
