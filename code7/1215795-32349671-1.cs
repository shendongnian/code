    /// <summary>
    /// Counts all the characters in a file sharing a reading buffer across multiple calls.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <param name="encoding">Encoding to use.</param>
    /// <param name="buffer">The buffer to share, will be recreated if it cannot contain the file.</param>
    /// <returns>The amount of characters in the file.</returns>
    public static int GetCharacterCount(string filePath, Encoding encoding, ref byte[] buffer)
    {
    	int fileLength;
    	using (var fstream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
    	{
    		fileLength = (int)fstream.Length;
    		// Expand the buffer if necessary
    		if (buffer == null || buffer.Length < fileLength)
    			buffer = new byte[fstream.Length];
    
    		if (fstream.Read(buffer, 0, fileLength) != fileLength)
    			throw new EndOfStreamException("Couldn't read all bytes from the file.");
    	}
    			
    	return encoding.GetCharCount(buffer, 0, fileLength);
    }
