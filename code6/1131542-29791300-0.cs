    private string EncodeFileAsBase64(string inputFileName)
        {
            byte[] binaryData;
            using (System.IO.FileStream inFile = new System.IO.FileStream(inputFileName,
                                       System.IO.FileMode.Open,
                                       System.IO.FileAccess.Read))
            {
                binaryData = new Byte[inFile.Length];
                long bytesRead = inFile.Read(binaryData, 0,
                                     (int)inFile.Length);
                inFile.Close();
            }
            // Convert the binary input into Base64 UUEncoded output. 
            string base64String;
            base64String = System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
            return base64String;
        }
