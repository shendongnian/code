    		FtpWebRequest lRequest = (FtpWebRequest)WebRequest.Create(serverPath);			
			lRequest.Method = WebRequestMethods.Ftp.UploadFile;
			lRequest.Credentials = new NetworkCredential(ftpUser, ftpPass);
			StreamReader lReader = new StreamReader(json);
			//convert steam to utf8
			byte[] lContents = Encoding.UTF8.GetBytes(lReader.ReadToEnd());
			lReader.Close();
			//Get length of data to post
			lRequest.ContentLength = lContents.Length;
			//Get your request stream
			Stream lRequestStream = lRequest.GetRequestStream();
			//Write to the stream
			lRequestStream.Write(lContents, 0, lContents.Length);
			//Close the stream
			lRequestStream.Close();
			//Get the response from the server
			FtpWebResponse lResponse = (FtpWebResponse)lRequest.GetResponse();
			//What is the actual status.
			MessageBox.Show(String.Format("Upload File Complete, status {0}", lResponse.StatusDescription));
