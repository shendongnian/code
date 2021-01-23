    // Convert byte array to integer array
    byte[] result = new byte[intArray.Length * sizeof(int)];
    Buffer.BlockCopy(intArray, 0, result, 0, result.Length);
    
    // Convert integer array to byte array (with bugs fixed)
    int[] result = new int[byteArray.Length + 1 / sizeof(int)];            
    Buffer.BlockCopy(byteArray, 0, result, 0, byteArray.Length);
