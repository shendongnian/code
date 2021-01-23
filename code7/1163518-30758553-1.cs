    // Save the document...
    string filename = Server.MapPath("~/PDF/" +  Url_SupplierId + ".pdf");
    document.Save(filename);
    using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
      {
        // Create a byte array of file stream length
        byte[] _downFile  = new byte[fs.Length];
        int numBytesToRead = (int)fs.Length;
        int numBytesRead = 0;
        //Read block of bytes from stream into the byte array
        while (numBytesToRead > 0)
          {
            // Read may return anything from 0 to numBytesToRead. 
            int n = fs.Read(_downFile, numBytesRead, numBytesToRead);
            // Break when the end of the file is reached. 
            if (n == 0)
              break;
            numBytesRead += n;
            numBytesToRead -= n;
          }
        numBytesToRead = _downFile.Length;
      }
    if (File.Exists(filename))
     File.Delete(filename);
    Response.Clear();
    Response.ClearContent();
    Response.ClearHeaders();
    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filename) + "; size=" + numBytesToRead);
    Response.BinaryWrite(_downFile);
    Response.Flush();
    Response.End();
