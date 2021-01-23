    Status UploadWithRetry(string sourceFile, string destinationFolder, int maxRetryCount, int retryIntervalSeconds)
    {      
   
        var fileName = Path.GetFileName(sourceFile);
        var uploadAttempts = 0;
        var success = false;
        var status = new FileTransferStatus { FilePath = sourceFile };
        while(uploadAttempts < maxRetryCount && !success){
            status = UploadFile(sourceFile);
            uploadAttempts++;
            success = status.Success;
        }
        if(uploadAttempts >= maxRetryCount){
            //throw new Exception(); //I would advise against this
            status.Message = "Max retry attempts reached."; //display this message to the frontend
        }
        return status;
    }
    Status UploadFile(string sourceFile){
        using (var fileStream = new FileStream(sourceFile, FileMode.Open))
        {
                Status uploadStatus = new FileTransferStatus { FilePath = sourceFile };
                try{
                 
                    _client.UploadFile(fileStream, destinationFilePath, null);
                    Status.Success = true;
                }
                catch(Exception ex){
                    Status.Success = false;
                }
                return uploadStatus;
            }
        }
    }
