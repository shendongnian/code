    // In reality you might want to figure out the array size based on the file size
    float[,] floatArray = new float[5000, 32];
    
    using (BinaryReader reader = new BinaryReader(File.Open(string.Format("{0}{1}.bin", DefaultFilePath, "MyBinaryFile"), FileMode.Open)))
    {
        for (x = 0; x < floatArray.GetLength(0); x++)
        {
            for (y = 0; y < floatArray.GetLength(1); y++)
                floatArray[x, y] = reader.ReadSingle();
        }
    }
