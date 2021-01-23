    public byte[] GetBytes(SqlDataReader reader)
    {
     const int MAXBUFFER = 4096;
     byte[] buffer = new byte[MAXBUFFER]
     using(MemoryStream ms = new MemoryStream())
     {
       int start = 0;
       long length;
       do
       {
          // Following is assuming column 0 has the byte data on the returned result set
          length = reader.GetBytes(0, start, buffer, 0, MAXBUFFER);
          ms.Write(buffer, 0, (int)length);
       }
       while(length == MAXBUFFER);
       return ms.ToArray();
     }
    }
