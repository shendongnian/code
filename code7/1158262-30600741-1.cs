    catch (WebException e)
            {
       if (e.Status == WebExceptionStatus.ProtocolError)
              {
                    file.WriteLine("\r\nWebException Raised. The following error occurrrrrrrrrrred : {0}", (int)myHttpWebResponse.StatusCode);              
              }
        else
              {
                    file.WriteLine("Error: {0}", e.Status);
              }
        file.Close();
            }
