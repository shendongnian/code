    private static readonly Thread Awesome = new Thread(Request);
    
    private const string Url = "http://whatever/";
    
    public static void Request() {
            const string filename = "names.txt";
            Reader.Readtext(filename);
    
            foreach (var names in Reader.Lastname) {
    
                var request = (HttpWebRequest) WebRequest.Create(Url + names);
                Console.WriteLine("Request Sent: " + Url + names);
                try{
                    var response = (HttpWebResponse) request.GetResponse();
                    var sr = new System.IO.StreamReader(response.GetResponseStream());
        
                    sr.ReadToEnd();            
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        var resp = ex.Response as HttpWebResponse;
                        if (resp != null && resp.StatusCode == HttpStatusCode.NotFound)
                        {
                            const string filename = "error.txt";
                            Writer.writetofile(filename, resp.ToString());
                        }
                    }
                }
            }
    }
    
    private static void Main()
    {
    
        Awesome.Start();
    }
