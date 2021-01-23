      bool directoryExists(string path)
        {
            bool? exists = null;
           
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential("username", "*****");
            
            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
                
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    string str = sr.ReadLine(); //Just needs to read one line to fire check on server
                    sr.Close();
                    return true;
                }                                    
            }
            catch (WebException ex)  
            {
                var r = (FtpWebResponse)ex.Response;
                if (r.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    //Does not exist
                    return false;
                }
                throw; //if error is not related to directory existence then the exception needs to be treated above.
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
            return false;
        }
