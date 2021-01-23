    public byte[] FileToByteArray(string fileName)
    {
                    byte[] buff = null;
                    FileStream fs = new FileStream(fileName,
                                                   FileMode.Open,
                                                   FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    long numBytes = new FileInfo(fileName).Length;
                    buff = br.ReadBytes((int)numBytes);
                    return buff;
    }
