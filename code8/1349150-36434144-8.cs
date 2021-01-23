        ReedSolomonEncoder enc = new ReedSolomonEncoder(GenericGF.AZTEC_DATA_12);//if i use AZTEC_DATA_8 it works fine beacuse symbol size is 8 bit
        int[] bytesAsInts = Array.ConvertAll(toBytes.ToArray(), c => (int)c);
        enc.encode(bytesAsInts, parity);
        // Turn int array to byte array without loosing value
        byte[] bytes = new byte[bytesAsInts.Length * sizeof(int)];
        Buffer.BlockCopy(bytesAsInts, 0, bytes, 0, bytes.Length);
        // Write to file
        File.WriteAllBytes(outputFileName, bytes);
        // Read from file
        bytes = File.ReadAllBytes(outputFileName);            
        
        // Turn byte array to int array 
        int bytesCount = bytes.Length * 40;
        int intsCount = bytesCount / sizeof(int);
        if (bytesCount % sizeof(int) != 0) intsCount++;
        int[] dataAsInts = new int[intsCount];
        Buffer.BlockCopy(bytes, 0, dataAsInts, 0, bytes.Length);
        
        // Decoding
        ReedSolomonDecoder dec = new ReedSolomonDecoder(GenericGF.AZTEC_DATA_12);
        dec.decode(dataAsInts, parity);
