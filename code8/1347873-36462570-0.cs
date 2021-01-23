    string inputFileName = @"input.264";
    string outputFileName = @"output.264";
                
    ReedSolomonEncoder enc = new ReedSolomonEncoder(GenericGF.AZTEC_DATA_12);
    ReedSolomonDecoder dec = new ReedSolomonDecoder(GenericGF.AZTEC_DATA_12);
              
    const int parity = 10;
                
    // open a file as stream for reading
    using (var input = File.OpenRead(inputFileName))
    {
        const int max_ints = 256;
        int[] bytesAsInts = new int[max_ints];
        // use a binary reader
        using (var binary = new BinaryReader(input))
        {
            for (int i = 0; i < max_ints - parity; i++)
            {
                //read a single byte, store them in the array of ints
                bytesAsInts[i] = binary.ReadByte();
            }
            // parity
            for (int i = max_ints - parity; i < max_ints; i++)
            {
                bytesAsInts[i] = 0;
            }
    
            enc.encode(bytesAsInts, parity);
                      
            bytesAsInts[1] = 3;
    
            dec.decode(bytesAsInts, parity);
    
            // create a stream for writing
            using(var output = File.Create(outputFileName))
            {
                // write bytes back
                using(var writer = new BinaryWriter(output))
                {
                    foreach(var value in bytesAsInts)
                    {
                        // we need to write back a byte
                        // not an int so cast it
                        writer.Write((byte)value);
                    }
                }
            }
        }
    }
