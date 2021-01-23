    void Write(string fileName, int[,] data)
    {
        using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(fileName)))
        {
            writer.Write(data.GetLength(0));
            writer.Write(data.GetLength(1));
    
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    writer.Write(data[x, y]);
                }
            }
        }
    }
    
    int[,] Read(string fileName)
    {
        using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName)))
        {
            int width = reader.ReadInt32();
            int height = reader.ReadInt32();
    
            int[,] result = new int[width, height];
    
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    result[x, y] = reader.ReadInt32();
                }
            }
    
            return result;
        }
    }
