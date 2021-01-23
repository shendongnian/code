    public static class ArraySerializer
    {
        public static void SaveToDisk(string path, SByte[,] input)
        {
            var length = input.GetLength(1);
            var height = input.GetLength(0);
            using (var fileStream = File.OpenWrite(path))
            {
                fileStream.Write(BitConverter.GetBytes(length), 0, 4);//Store the length
                fileStream.Write(BitConverter.GetBytes(height), 0, 4);//Store the height
                var lineBuffer = new byte[length];
                for (int h = 0; h < height; h++) 
                {
                    for (int l = 0; l < length; l++) 
                    {
                        unchecked //Preserve sign bit
                        {
                            lineBuffer[l] = (byte)input[h,l];
                        }
                    }
                    fileStream.Write(lineBuffer,0,length);
                }
                
            }
        }
        public static SByte[,] ReadFromDisk(string path)
        {
            using (var fileStream = File.OpenRead(path))
            {
                int length;
                int height;
                var intBuffer = new byte[4];
                fileStream.Read(intBuffer, 0, 4);
                length = BitConverter.ToInt32(intBuffer, 0);
                fileStream.Read(intBuffer, 0, 4);
                height = BitConverter.ToInt32(intBuffer, 0);
                var output = new SByte[height, length]; //Note, for large allocations, this can fail... Would fail regardless of how you read it back
                var lineBuffer = new byte[length];
                for (int h = 0; h < height; h++)
                {
                    fileStream.Read(lineBuffer, 0, length);
                    for (int l = 0; l < length; l++)
                        unchecked //Preserve sign bit
                        {
                            output[h,l] = (SByte)lineBuffer[l];
                        }
                }
                return output;
            }
        }
    }
