    string path = @"D:\videos\myvideos.mpeg";
    try
    {
        using (FileStream fsSource = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[] bytes = new byte[fsSource.Length];
            int numBytesToRead = (int)fsSource.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                // Read may return anything from 0 to numBytesToRead. 
                int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);
                // Break when the end of the file is reached. 
                if (n == 0)
                    break;
                numBytesRead += n;
                numBytesToRead -= n;
            }
            
			SqlCommand Cmd = Connection.CreateCommand();
			Cmd.CommandText = "Insert Into MyTable(ID,Video,FileName,Format,Size)Values(@ID,@Video,@FileName,@Format,@Size)";
			Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = 1;
			Cmd.Parameters.Add("@Video", SqlDbType.VarBinary).Value = bytes;
			Cmd.Parameters.Add("@FileName", SqlDbType.Varchar).Value = "My File Name";
			Cmd.Parameters.Add("@Format", SqlDbType.Varchar).Value = "MPEG";
			Cmd.Parameters.Add("@Size", SqlDbType.Int).Value = bytes.length;
			Cmd.ExecuteNonQuery();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
