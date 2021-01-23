    // serialize
    var intArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
    var byteArray = new byte[intArray.Length * 4];
    Buffer.BlockCopy(intArray, 0, byteArray, 0, byteArray.Length);
    // deserialize and test
    var intArray2 = new int[byteArray.Length / 4];
    Buffer.BlockCopy(byteArray, 0, intArray2, 0, byteArray.Length);
    Console.WriteLine(intArray.SequenceEqual(intArray2));    // true
