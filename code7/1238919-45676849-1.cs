    private void Form1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
    {
      string [] fileNames = null;
    
      try
      {
        if ( e.Data.GetDataPresent(DataFormats.FileDrop,false) == true)
        {
          fileNames = (string []) e.Data.GetData(DataFormats.FileDrop);
          // handle each file passed as needed
          foreach( string fileName in fileNames)
          {
            // do what you are going to do with each filename
          }
        }
        else if (e.Data.GetDataPresent("FileGroupDescriptor"))
        {
          //
          // the first step here is to get the filename
          // of the attachment and
          // build a full-path name so we can store it
          // in the temporary folder
          //
    
          // set up to obtain the FileGroupDescriptor
          // and extract the file name
          Stream theStream = (Stream) e.Data.GetData("FileGroupDescriptor");
          byte [] fileGroupDescriptor = new byte[512];
          theStream.Read(fileGroupDescriptor,0,512);
          // used to build the filename from the FileGroupDescriptor block
          StringBuilder fileName = new StringBuilder("");
          // this trick gets the filename of the passed attached file
          for(int i=76; fileGroupDescriptor[i]!=0; i++)
          {  fileName.Append(Convert.ToChar(fileGroupDescriptor[i]));}
          theStream.Close();
          string path = Path.GetTempPath();
              // put the zip file into the temp directory
          string theFile = path+fileName.ToString();
              // create the full-path name
    
          //
          // Second step:  we have the file name.
          // Now we need to get the actual raw
          // data for the attached file and copy it to disk so we work on it.
          //
    
          // get the actual raw file into memory
          MemoryStream ms = (MemoryStream) e.Data.GetData(
              "FileContents",true);
          // allocate enough bytes to hold the raw data
          byte [] fileBytes = new byte[ms.Length];
          // set starting position at first byte and read in the raw data
          ms.Position = 0;
          ms.Read(fileBytes,0,(int)ms.Length);
          // create a file and save the raw zip file to it
          FileStream fs = new FileStream(theFile,FileMode.Create);
          fs.Write(fileBytes,0,(int)fileBytes.Length);
    
          fs.Close();  // close the file
    
          FileInfo tempFile = new FileInfo(theFile);
    
          // always good to make sure we actually created the file
          if ( tempFile.Exists == true)
          {
            // for now, just delete what we created
            tempFile.Delete();
          }
          else
          {  Trace.WriteLine("File was not created!");}
        }
    
      }
      catch (Exception ex)
      {
        Trace.WriteLine("Error in DragDrop function: " + ex.Message);
    
        // don't use MessageBox here - Outlook or Explorer is waiting !
      }
    
    }
