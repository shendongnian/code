    using (BinaryReader br = new BinaryReader(File.Open(textBox1.Text, FileMode.Open)))
	{
	    int pos = 0;
	    int length = (int)b.BaseStream.Length;
        int numBytesToRead = 1;
	    while (pos < length)
	    {
            byte[] buffer = br.ReadBytes(numBytesToRead);
            for (int i = 0; i < buffer.Count; i++)
            {
                Byte b = buffer[i];
                textEditor.Text += b.ToString("X2");
         		pos += sizeof(numBytesToRead);
            }
	    }
	}
