    public static SqlBytes Compress(byte[] input)
    {
    
        using (MemoryStream memstream = new MemoryStream())
        {    
            using (GZipStream zipped = new GZipStream(memstream, CompressionMode.Compress))
            {               
                zipped.Write(input, 0, input.Length);
            }   
			
			return new SqlBytes(memstream);    			
        }
    }
