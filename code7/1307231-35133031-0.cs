    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    
    ...
    public static void UploadXMLToFTP (XmlDocument xml)
    {
        // Get the object used to communicate with the server.
        using(FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/test.htm"))
        {
			request.Method = WebRequestMethods.Ftp.UploadFile;
			
			// This example assumes the FTP site uses anonymous logon.
			request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
			
			// Copy the contents of the file to the request stream.
			request.ContentLength = xml.OuterXml.Length;
			
			Stream requestStream = request.GetRequestStream();
   			xml.Save(requestStream);
            requestStream.Close();
	
			
			FtpWebResponse response = (FtpWebResponse)request.GetResponse();
			
			Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
			
			response.Close();
        }
    }
