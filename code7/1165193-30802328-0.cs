    public ActionResult list()
    {
             Uri firstUrl = new Uri("ftp.xyz.com");
                List<JSchema> tst = DisplayList(firstUrl);
                return View(tst);
            }
     
    
     public static List<JSchema> DisplayList(Uri serverUri)
            {
                List<String> tet = new List<String>();
                FtpWebRequest Request = (FtpWebRequest)WebRequest.Create(serverUri);
                Request.Credentials = new NetworkCredential("username", "password");
                Request.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse Response = (FtpWebResponse)Request.GetResponse();
                Stream ResponseStream = Response.GetResponseStream();
                StreamReader Reader = new StreamReader(ResponseStream);
                
                //JSchema sch =  JSchema.Parse(jsonsch);
                int counter = 0; 
                while (!Reader.EndOfStream)//Read file name
                {
                    string temp = Reader.ReadLine();
                    tet.Add( @"{'id' : '" + temp + "', 'parent' : '#','text' :'" + temp + "' }");
                    
                    counter++;
                }// end while
    
                List<JSchema> js = new List<JSchema>();
                
                for (int i =0; i<counter ; i++ )
                {
                   js.Add ( JSchema.Parse(tet[i]));
                }
                
                Response.Close();
                ResponseStream.Close();
                Reader.Close();
                
                return js;
              
    
            }// end display list
