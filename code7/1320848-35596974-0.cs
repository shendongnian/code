    SqlConnection conn = new SqlConnection("Data Source=localhost;Integrated Security=SSPI;Initial Catalog=pubs;");
    SqlCommand cmd = new SqlCommand("SELECT fileID, filePDF FROM myFiles", conn);   //filePDF is BLOB column
    
    FileStream fs;                          // Writes the BLOB to a file
    BinaryWriter bw;                        // Streams the BLOB to the FileStream object.
    
    int bufferSize = 1000;                  // Max dimension of your PDF file in bytes.
    byte[] outbyte = new byte[bufferSize];  // The BLOB byte[] buffer to be filled by GetBytes.
    long retval;                            // The bytes returned from GetBytes.
    long startIndex = 0;                    // The starting position in the BLOB output.
    
    string fileID = "";                     // The publisher id to use in the file name.
    
    // Open the connection and read data into the DataReader.
    conn.Open();
    SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
    
    while (myReader.Read())
    {
      fileID = myReader.GetString(0);  
    
      fs = new FileStream("file_pdf" + fileID + ".pdf", FileMode.OpenOrCreate, FileAccess.Write);
      bw = new BinaryWriter(fs);
    
      startIndex = 0;
    
      retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
    
      while (retval == bufferSize)
      {
        bw.Write(outbyte);
        bw.Flush();
    
        startIndex += bufferSize;
        retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
      }
    
      bw.Write(outbyte, 0, (int)retval - 1);
      bw.Flush();
    
      bw.Close();
      fs.Close();
    }
    
    myReader.Close();
    conn.Disponse();
    conn.Close();
