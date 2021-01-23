 	if (RadUpload1.UploadedFiles.Count <= 0) // Changed the condition to remove the check within the else block
	{
		Session[AppConstants.ERROR_MESSAGE] = ErrorsList.GetErrorMessage(
			ErrorsList.ERR_P_DATE_FILE_VALID);
	}
	else
	{
		foreach (UploadedFile validFile in RadUpload1.UploadedFiles)
		{
			FileInfo fi = new FileInfo(validFile.FileName);
			Stream fs = validFile.InputStream;
			IDbContextualRecord pFile = statusContext.CreateAndAddRecordForInsert(PartStoredFile.t_name);
			pFile[PartStoredFile.c_partId] = _part[Part.c_id];
			string targetFolder = AppSession.Current.ConfigParameters[AppConstants.UPLOAD_FILE_PATH] +
								  "\\partRec\\" + _part[Part.c_id] + "\\" + pFile[PartStoredFile.c_id];
			long bytesOnTheStream = 0L;
			try
			{
				DirectoryInfo dir = new DirectoryInfo(targetFolder);
				if (dir.Exists == false)
					dir.Create();
				string fullFileName = Path.Combine(targetFolder, fi.Name);
				if(fullFileName.Length > 260)
				{
					throw new Exception(string.Format("The filename {0} is too long.", fullFileName));
					// Or do whatever you want
				}
				Stream targetStream = File.OpenWrite(fullFileName);
				byte[] buffer = new Byte[AppConstants.BUFF_SIZE];
				int bytesRead;
				// while the read method returns bytes
				// keep writing them to the output stream
				while ((bytesRead = fs.Read(buffer, 0, AppConstants.BUFF_SIZE)) > 0)
				{
					targetStream.Write(buffer, 0, bytesRead);
					bytesOnTheStream += bytesRead;
				}
				fs.Close();
				targetStream.Close();
			}
			catch (Exception ex)
			{
				throw;
			}
