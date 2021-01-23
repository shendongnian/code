            var request = (FtpWebRequest)WebRequest.Create
    ("ftp://ftp.domain.com/doesntexist.txt");
            request.Credentials = new NetworkCredential("user", "pass");
            request.Method = WebRequestMethods.Ftp.GetFileSize;
    
            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    //Does not exist
                }
            }
            catch(Exception e)
            {
            }
