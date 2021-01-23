        string path = "c://csvfolder";                      
        string fileName = "FileName.csv";
        StreamWriter SW = new StreamWriter(path, false);
         SW.Write( /*Can create the comma sperated items*/);
        /*Create y our CSV file data here*/
        
        fs = File.Open(path, FileMode.Open);
        int BUFFER_SIZE = Convert.ToInt32(fs.Length);
        int nBytesRead = 0;
        Byte[] Buffer = new Byte[BUFFER_SIZE];
        nBytesRead = fs.Read(Buffer, 0, BUFFER_SIZE);
        fs.Close();
        Response.AddHeader("Content-disposition", "attachment; filename=" + fileName);
        Response.ContentType = "application/octet-stream";
        Response.BinaryWrite(Buffer);
        Response.Flush();
        Response.End();
