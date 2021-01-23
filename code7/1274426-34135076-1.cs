    // The string we are working with.
    string str = @"1010101010010100010101101";
    // The number of bits in a 64 bit integer!
    int size = 64;
    // Pad the end of the string with zeros so the length of the string is divisible by 64.
    str += new string('0', str.Length % size);
    // Convert each 64 character segment into a 64 bit integer.
    long[] binary = new long[str.Length / size]
        .Select((x, idx) => Convert.ToInt64(str.Substring(idx * size, size), 2)).ToArray();
    // Copy the result to a byte array.
    byte[] bytes = new byte[binary.Length * sizeof(long)];
    Buffer.BlockCopy(binary, 0, bytes, 0, bytes.Length);
    // Write the result to file.
    File.WriteAllBytes("MyFile.bin", bytes);
