    using (BinaryWriter bw = new BinaryWriter(File.Open(madecabfilePath, FileMode.OpenOrCreate)))
    using (BinaryReader reader = new BinaryReader(new FileStream(madefilePath, FileMode.Open)))
    {
        reader.BaseStream.Seek(offset, SeekOrigin.Begin);
        while (!isComplete)
        {
            int charsRead = reader.Read(test, 0, weight);
            if (charsRead == 0)
            {
                isComplete = true;
            }
            else
            {
                bw.Write(test, 0, charsRead);
            }
        }
    }
